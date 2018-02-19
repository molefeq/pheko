<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
  <xsl:template match="PatientConsultationSickNote">

    <document>

      <xsl:call-template name="SurgeryDetails">
        <xsl:with-param select="Surgery" name="SurgeyInformation"></xsl:with-param>
      </xsl:call-template>

      <xsl:call-template name="PatientSickNoteDetails">
        <xsl:with-param select="PatientSickNote" name="PatientSickNote"></xsl:with-param>
      </xsl:call-template>

    </document>

  </xsl:template>

  <xsl:template name="SurgeryDetails">
    <xsl:param name="SurgeyInformation"></xsl:param>

    <table columns="2" keeptogether="true" width="100.00" widths="50.00, 50.00">
      <row>
        <cell borderwidth="0" rowspan="4">
          <image width="1000.00" height="40.00">
            <xsl:apply-templates select="$SurgeyInformation/Logo"/>
          </image>
        </cell>
        <cell borderwidth="0">
          <phrase font="Helvetica" size="8.0" bold="false">
            <xsl:apply-templates select="$SurgeyInformation/Address1"/>
          </phrase>
        </cell>
      </row>
      <row>
        <cell borderwidth="0">
          <phrase font="Helvetica" size="8.0" bold="false">
            <xsl:apply-templates select="$SurgeyInformation/Address2"/>
          </phrase>
        </cell>
      </row>
      <row>
        <cell borderwidth="0">
          <phrase font="Helvetica" size="8.0" bold="false">
            Tel: <xsl:apply-templates select="$SurgeyInformation/TelephoneNumber"/> Fax: <xsl:apply-templates select="$SurgeyInformation/FaxNumber"/>
          </phrase>
        </cell>
      </row>
      <row>
        <cell borderwidth="0">
          <phrase font="Helvetica" size="8.0" bold="false">
            Email: <xsl:apply-templates select="$SurgeyInformation/EmailAddress"/>
          </phrase>
        </cell>
      </row>
      <row>
        <cell borderwidth="0">
          <phrase font="Helvetica" size="8.0" bold="false">
            <xsl:apply-templates select="$SurgeyInformation/WebSite"/>
          </phrase>
        </cell>
      </row>
    </table>

  </xsl:template>

  <xsl:template name="PatientSickNoteDetails">
    <xsl:param name="PatientSickNote"></xsl:param>


    <table columns="1" widths="100.00" keeptogether="true" width="100.00">
      <row>
        <cell borderwidth="0.5">
          <table columns="2" keeptogether="true" width="100.00" widths="30.00,70.00">
            <row>
              <cell colspan="2" bottomborderwidth="0.5" height="25.0" indentation="5.0" leftborderwidth="0" rightborderwidth="0" topborderwidth="0">
                <phrase font="Helvetica" size="10.0" bold="true">Medical Certificate</phrase>
              </cell>
            </row>
            <row>
              <cell borderwidth="0" leftpadding="2.0" >
                <phrase font="Helvetica" size="8.0" bold="true">This is to certify that: </phrase>
              </cell>
              <cell borderwidth="0">
                <phrase font="Helvetica" size="8.0" bold="false">
                  <xsl:apply-templates select="$PatientSickNote/PatientDetails"/>
                </phrase>
              </cell>
            </row>
            <row>
              <cell borderwidth="0" leftpadding="2.0">
                <phrase font="Helvetica" size="8.0" bold="true">Was attended on: </phrase>
              </cell>
              <cell borderwidth="0">
                <phrase font="Helvetica" size="8.0" bold="false">
                  <xsl:apply-templates select="$PatientSickNote/ConsultationDate"/>
                </phrase>
              </cell>
            </row>
            <row>
              <cell borderwidth="0" leftpadding="2.0">
                <phrase font="Helvetica" size="8.0" bold="true">Reports to have been sick from: </phrase>
              </cell>
              <cell rightpadding="3.0" toppadding="3.0" borderwidth="0">
                <table columns="1" keeptogether="true" width="100.00" widths="100.00">
                  <row>
                    <cell borderwidth="0.5" height="40.0" leftpadding="3.0">
                      <phrase font="Helvetica" size="8.0" bold="false" leading="0">
                        <xsl:apply-templates select="$PatientSickNote/SicknessReason"/>
                      </phrase>
                    </cell>
                  </row>
                </table>
              </cell>
            </row>
            <row>
              <cell borderwidth="0" leftpadding="2.0">
                <phrase font="Helvetica" size="8.0" bold="true">Diagnoses: </phrase>
              </cell>
              <cell rightpadding="3.0" toppadding="3.0" borderwidth="0">
                <table columns="1" keeptogether="true" width="100.00" widths="100.00">
                  <row>
                    <cell borderwidth="0.5" height="40.0" leftpadding="3.0">
                      <phrase font="Helvetica" size="8.0" bold="false" leading="0">
                        <xsl:apply-templates select="$PatientSickNote/Diagnoses"/>
                      </phrase>
                    </cell>
                  </row>
                </table>
              </cell>
            </row>
            <row>
              <cell borderwidth="0" leftpadding="2.0">
                <phrase font="Helvetica" size="8.0" bold="true">Sick leave from: </phrase>
              </cell>
              <cell borderwidth="0">
                <phrase font="Helvetica" size="8.0" bold="false">
                  <xsl:apply-templates select="$PatientSickNote/SickLeaveStartDate"/> To <xsl:apply-templates select="$PatientSickNote/SickLeaveEndDate"/>
                </phrase>
              </cell>
            </row>
            <row>
              <cell borderwidth="0" leftpadding="2.0">
                <phrase font="Helvetica" size="8.0" bold="true">Review: </phrase>
              </cell>
              <cell borderwidth="0">
                <phrase font="Helvetica" size="8.0" bold="false">
                  <xsl:apply-templates select="$PatientSickNote/Review"/>
                </phrase>
              </cell>
            </row>
            <row>
              <cell borderwidth="0" leftpadding="2.0">
                <phrase font="Helvetica" size="8.0" bold="true">Thank you: </phrase>
              </cell>
              <cell borderwidth="0">
                <table columns="2" widths="60, 40" width="100">
                  <row>
                    <cell bottomborderwidth="0.5" leftborderwidth="0" rightborderwidth="0" topborderwidth="0" rightpadding="20.0">
                      <phrase font="Helvetica" size="8.0" bold="false">
                      </phrase>
                    </cell>
                    <cell borderwidth="0">
                      <phrase font="Helvetica" size="8.0">
                      </phrase>
                    </cell>
                  </row>
                </table>
              </cell>
            </row>
            <row>
              <cell borderwidth="0" leftpadding="2.0">
                <phrase font="Helvetica" size="8.0" bold="true">Doctor: </phrase>
              </cell>
              <cell borderwidth="0">
                <table columns="2" widths="60, 40" width="100">
                  <row>
                    <cell bottomborderwidth="0.5" leftborderwidth="0" rightborderwidth="0" topborderwidth="0" rightpadding="20.0">
                      <phrase font="Helvetica" size="8.0" bold="false">
                        <xsl:apply-templates select="$PatientSickNote/DoctorDetails"/>
                      </phrase>
                    </cell>
                    <cell borderwidth="0">
                      <phrase font="Helvetica" size="8.0">
                      </phrase>
                    </cell>
                  </row>
                </table>
              </cell>
            </row>
            <row>
              <cell borderwidth="0" leftpadding="2.0">
                <phrase font="Helvetica" size="8.0" bold="true">Signature: </phrase>
              </cell>
              <cell borderwidth="0">
                <table columns="2" widths="60, 40" width="100">
                  <row>
                    <cell bottomborderwidth="0.5" leftborderwidth="0" rightborderwidth="0" topborderwidth="0" rightpadding="20.0">
                      <phrase font="Helvetica" size="8.0" bold="false">
                      </phrase>
                    </cell>
                    <cell borderwidth="0">
                      <phrase font="Helvetica" size="8.0">
                      </phrase>
                    </cell>
                  </row>
                </table>
              </cell>
            </row>
            <row>
              <cell borderwidth="0" leftpadding="2.0">
                <phrase font="Helvetica" size="8.0" bold="true">Date: </phrase>
              </cell>
              <cell borderwidth="0">
                <table columns="2" widths="60, 40" width="100">
                  <row>
                    <cell bottomborderwidth="0.5" leftborderwidth="0" rightborderwidth="0" topborderwidth="0" rightpadding="20.0">
                      <phrase font="Helvetica" size="8.0" bold="false">
                      </phrase>
                    </cell>
                    <cell borderwidth="0">
                      <phrase font="Helvetica" size="8.0">
                      </phrase>
                    </cell>
                  </row>
                </table>
              </cell>
            </row>
          </table>
        </cell>
      </row>
    </table>
  </xsl:template>
</xsl:stylesheet>
