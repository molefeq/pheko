(function ($) {

    $.fn.grid = function (options) {
        var settings = $.extend({
            width: '100%',
            backgroundColor: 'gray',
            pageSize: '10',
            pageIndex: '1'
        }, options);

        var grid_container = $('<div class="container-fluid grid"></div>');

        grid_container.append(create_grid_columns(settings.columns, settings.toolbar));

        this.append(grid_container);

        if (!settings.async) {
            this.append(create_grid_paging(settings.pageSize, settings.pageIndex, settings.data.length));
            var viewModel = {
                griddata: ko.observableArray(settings.data),
                custom_colum_post: function (date, event, fields) {
                    var column_data = '';

                    $.each(fields.split(','), function (index, field) {
                        column_data = column_data + ',' + field + ':' + data(field);
                    });

                    column_data = '{' + column_data.substring(1, column_data.length) + '}';
                    custom_column_post(column.url, column_data);
                }
            };
            ko.applyBindings(viewModel, grid_container[0]);
        }
        else {
            load_grid_data(settings.url, settings.pageSize, settings.pageIndex, grid_container);
        }

        return this;
    }

    function create_grid_columns(columns, toolbar) {
        var grid_table = $('<table class="table table-condensed table-hover"></table>');

        if (columns.length > 0) {
            var table_grid_header = $("<thead></thead>");
            var table_grid_header_row = $("<tr></tr>");

            //if (toolbar.edit) {
            //    table_grid_header_row.append('<th></th>');
            //}

            $.each(columns, function (index, column) {
                table_grid_header_row.append('<th>' + column.title + '</th>');
            });

            table_grid_header.append(table_grid_header_row);
            grid_table.append(table_grid_header);

            var table_grid_body = $("<tbody data-bind='foreach: griddata'></tbody>");
            var table_grid_body_row = $("<tr></tr>");

            //if (toolbar.edit) {
            //    var edit_button_cell = $('<td></td>');
            //    var edit_button = $('<input type="button" data-bind="attr: {id: ' + toolbar.id + '}" value="edit"/>');

            //    $(edit_button).on('click', function (button) {
            //        button.preventDefault();

            //    });

            //    edit_button_cell.append(edit_button);
            //    table_grid_body_row.append(edit_button_cell);
            //}

            $.each(columns, function (index, column) {
                if (column.type && column.type == 'custombutton') {
                    var edit_button_cell = $('<td></td>');
                    var data_fields = '';
                    var fields = '';

                    //$.each(column.data, function (index, field) {
                    //    data_fields = data_fields + '&' + field.field + ' : ' + field.field;
                    //    fields = ',' + field.field;
                    //});

                    //data_fields = data_fields.substring(1, data_fields.length);
                    //fields = fields.substring(1, fields.length);
                    var href_value = '\'' + column.url + '?id=\' + ' + column.modelid;

                    var link_element = $('<a data-bind="attr: {href: ' + href_value + '}">' + column.value + '</a>');


                    //$(edit_button).on('click', function (button) {
                    //    button.preventDefault();
                    //    if (column.httpverb.toLowerCase() == 'post') {
                    //        var column_data = '';

                    //        $.each(column.data, function (index, field) {
                    //            column_data = column_data + ',' + field.field + ':' + $(button).attr('field_' + field.field);
                    //        });

                    //        column_data = '{' + column_data.substring(1, column_data.length) + '}';
                    //        custom_column_post(column.url, column_data);
                    //    }
                    //});

                    edit_button_cell.append(link_element);
                    table_grid_body_row.append(edit_button_cell);
                }
                else {
                    table_grid_body_row.append('<td data-bind="text: ' + column.field + '"></td>');
                }
            });

            table_grid_body.append(table_grid_body_row);
            grid_table.append(table_grid_body);
        }

        return grid_table;
    }

    function create_grid_paging(pageSize, pageIndex, totalRows) {
        var total_pages = Math.ceil(totalRows / pageSize);
        var is_total_page_greater_than_10 = total_pages > 10;
        var page_interval = Math.floor(pageIndex / 10);

        var paging_holder = $('<ul class="pagination"></ul>');

        if (pageIndex == 1) {
            paging_holder.append('<li class="disabled"><a href="#">&laquo;</a></li>')
        }
        else {
            paging_holder.append('<li><a href="#">&laquo;</a></li>')
        }

        var start_page = (page_interval - 1) * 10 + 1;

        if (is_total_page_greater_than_10) {
            for (var i = start_page; i <= start_page + 10; i++) {
                if (total_pages >= i) {
                    if (pageIndex == i) {
                        paging_holder.append('<li class="active"><a href="#">' + i + '<span class="sr-only">(current)</span></a></li>');
                    }
                    else {
                        paging_holder.append('<li><a href="#">' + i + '</a></li>');
                    }
                }
            }

            if (pageIndex == total_pages) {
                paging_holder.append('<li class="disabled"><a href="#">&raquo;</a></li>')
            }
            else {
                paging_holder.append('<li><a href="#">&raquo;</a></li>')
            }
        }

        return paging_holder;
    }

    function load_grid_data(url, pageSize, pageIndex, grid_container) {
        $.ajax({
            type: "GET",
            url: url,
            cache: false,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                //this.append(create_grid_paging(pageSize, pageIndex, response.total));
                var viewModel = {
                    griddata: ko.observableArray(response.data),
                    editPatient: function (target, event) {
                        $.ajax({
                            type: "POST",
                            url: toolbar.edit.url,
                            cache: false,
                            data: { patientId: $(target).attr('id') },
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            success: function (response) {

                            },
                            error: function (error) {
                                alert(error.status + "<--and--> " + error.statusText);
                            }
                        });
                    }
                };
                ko.applyBindings(viewModel, grid_container[0]);
            },
            error: function (error) {
                alert(error.status + "<--and--> " + error.statusText);
            }
        });
    }

    function custom_column_post(url, data) {
        $.ajax({
            type: "POST",
            url: url,
            cache: false,
            data: data,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {

            },
            error: function (error) {
                alert(error.status + "<--and--> " + error.statusText);
            }
        });
    }

}(jQuery));