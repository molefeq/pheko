<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
  <xsl:template match="PatientScript">

    <document>

      <xsl:call-template name="SurgeryDetails">
        <xsl:with-param select="Surgery" name="SurgeyInformation"></xsl:with-param>
      </xsl:call-template>

      <xsl:call-template name="PatientScriptDetails">
        <xsl:with-param select="PatientScript" name="PatientScript"></xsl:with-param>
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

  <xsl:template name="PatientScriptDetails">
    <xsl:param name="PatientScript"></xsl:param>

    <table columns="2" keeptogether="true" width="100.00" widths="10.00,90.00">
      <row>
        <cell borderwidth="0" leftpadding="2.0" >
          <phrase font="Helvetica" size="8.0" bold="true">Patient: </phrase>
        </cell>
        <cell borderwidth="0">
          <phrase font="Helvetica" size="8.0" bold="false">
            <xsl:apply-templates select="PatientScript/PatientDetails"/>
          </phrase>
        </cell>
      </row>
      <row>
        <cell borderwidth="0" leftpadding="2.0">
          <phrase font="Helvetica" size="8.0" bold="true">Dr: </phrase>
        </cell>
        <cell borderwidth="0">
          <phrase font="Helvetica" size="8.0" bold="false">
            <xsl:apply-templates select="PatientScript/DoctorDetails"/>
          </phrase>
        </cell>
      </row>
      <row>
        <cell borderwidth="0" leftpadding="2.0">
          <phrase font="Helvetica" size="8.0" bold="true">Signature: </phrase>
        </cell>
        <cell borderwidth="0">
          <phrase font="Helvetica" size="8.0" bold="false">
          </phrase>
        </cell>
      </row>
      <row>
        <cell borderwidth="0" leftpadding="2.0">
          <phrase font="Helvetica" size="8.0" bold="true">Date: </phrase>
        </cell>
        <cell borderwidth="0">
          <phrase font="Helvetica" size="8.0" bold="false">
          </phrase>
        </cell>
      </row>
      <row>
        <cell rightpadding="3.0" toppadding="3.0" borderwidth="0" colspan="2">
          <table columns="1" keeptogether="true" width="100.00" widths="100.00">
            <row>
              <cell borderwidth="0.5" height="200.00" leftpadding="3.0">
              </cell>
            </row>
          </table>
        </cell>
      </row>
    </table>
  </xsl:template>
</xsl:stylesheet>
