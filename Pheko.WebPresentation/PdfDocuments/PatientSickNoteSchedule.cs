using Itextsharp.CustomXmlToPdfWriter;

using Pheko.WebPresentation.ServiceHandlers.Classes;

using System;
using System.Data;
using System.IO;
using System.Web;

namespace Pheko.WebPresentation.PdfDocuments
{
    public class PatientSickNoteSchedule
    {
        public static void CreatePatientSickNoteSchedulePdf(int patientConsultationId, int userId, string xsltDirectory,
                                                              HttpContextBase context, MemoryStream memoryStream)
        {
            DocumentScheduleHandler documentScheduleHandler = new DocumentScheduleHandler();
            DataSet dataSet = documentScheduleHandler.GetPatientSickNoteSchedule(patientConsultationId, userId);
            
            dataSet.DataSetName = "PatientConsultationSickNote";
            dataSet.Tables[0].TableName = "Surgery";
            dataSet.Tables[1].TableName = "PatientSickNote";

            DataRow dataRow = dataSet.Tables["Surgery"].Rows[0];

            dataRow["Logo"] = context.Server.MapPath(dataRow["Logo"].ToString());

            XmlPdfWriter.WritePdf(dataSet, xsltDirectory + "PateintSickNote.xslt", memoryStream);
        }
    }
}
