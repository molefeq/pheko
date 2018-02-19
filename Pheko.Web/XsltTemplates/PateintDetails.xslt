<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl">

  <xsl:template match="PatientSchedule">

    <document>

      <xsl:call-template name="SurgeryDetails">
        <xsl:with-param select="Surgery" name="SurgeyInformation"></xsl:with-param>
      </xsl:call-template>

      <xsl:call-template name="PatientDetails">
        <xsl:with-param select="PatientDetails" name="PatientInformation"></xsl:with-param>
      </xsl:call-template>

      <xsl:call-template name="MedicalAidDetails">
        <xsl:with-param select="PatientDetails" name="MedicalAidInformation"></xsl:with-param>
        <xsl:with-param select="MedicalAidDetails" name="MedicalAidDependancy"></xsl:with-param>
      </xsl:call-template>

      <xsl:call-template name="VitalSignDetails">
        <xsl:with-param select="PatientVitalSigns" name="PatientVitalSigns"></xsl:with-param>
        <xsl:with-param select="Surgery" name="SurgeyInformation"></xsl:with-param>
      </xsl:call-template>

      <xsl:call-template name="MedicalNoteDetails">
        <xsl:with-param select="Surgery" name="SurgeyInformation"></xsl:with-param>
        <xsl:with-param select="PatientChronicDeseases" name="PatientChronicDeseases"></xsl:with-param>
        <xsl:with-param select="PatientDeseaseScreenings" name="PatientDeseaseScreenings"></xsl:with-param>
        <xsl:with-param select="PatientPastMedicalHistories" name="PatientPastMedicalHistories"></xsl:with-param>
        <xsl:with-param select="PatientMedicalNotes" name="PatientMedicalNotes"></xsl:with-param>
        <xsl:with-param select="PatientClinicalExaminations" name="PatientClinicalExaminations"></xsl:with-param>
        <xsl:with-param select="PatientMedicalMonitoring" name="PatientMedicalMonitoring"></xsl:with-param>
      </xsl:call-template>

    </document>

  </xsl:template>

  <xsl:template name="SurgeryDetails">
    <xsl:param name="SurgeyInformation"></xsl:param>

    <table columns="2" keeptogether="true" width="100.00" widths="50.00, 50.00" type="normal">
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

  <xsl:template name="PatientDetails">
    <xsl:param name="PatientInformation"></xsl:param>

    <table columns="4" keeptogether="true" width="100.00">
      <row>
        <cell borderwidth="0" leftpadding="2.0">
          <phrase font="Helvetica" size="10.0" bold="false">File Number</phrase>
        </cell>
        <cell borderwidth="0">
          <phrase font="Helvetica" size="10.0" bold="false">
            <xsl:apply-templates select="$PatientInformation/PatientId"/>
          </phrase>
        </cell>
        <cell borderwidth="0">
          <phrase font="Helvetica" size="10.0" bold="false"></phrase>
        </cell>
        <cell borderwidth="0">
          <phrase font="Helvetica" size="10.0" bold="false"></phrase>
        </cell>
      </row>
    </table>

    <table columns="1" widths="100.00" keeptogether="true" width="100.00">
      <row>
        <cell borderwidth="0.5">
          <table columns="4" keeptogether="true" width="100.00" widths="20,30,20,30">
            <row>
              <cell colspan="4" bottomborderwidth="0.5" height="25.0" indentation="5.0" leftborderwidth="0" rightborderwidth="0" topborderwidth="0">
                <phrase font="Helvetica" size="12.0" bold="false" leading="0">Patient Information</phrase>
              </cell>
            </row>
            <row>
              <cell borderwidth="0" leftpadding="2.0">
                <phrase font="Helvetica" size="8.0" bold="false">Patient</phrase>
              </cell>
              <cell borderwidth="0">
                <phrase font="Helvetica" size="8.0" bold="true">
                  <xsl:apply-templates select="$PatientInformation/PatientName"/>
                </phrase>
              </cell>
              <cell borderwidth="0">
                <phrase font="Helvetica" size="8.0" bold="false">Date Of Birth</phrase>
              </cell>
              <cell borderwidth="0">
                <phrase font="Helvetica" size="8.0" bold="true">
                  <xsl:apply-templates select="$PatientInformation/BirthDate"></xsl:apply-templates>
                </phrase>
              </cell>
            </row>
            <row>
              <cell borderwidth="0" leftpadding="2.0">
                <phrase font="Helvetica" size="8.0" bold="false">Age</phrase>
              </cell>
              <cell borderwidth="0">
                <phrase font="Helvetica" size="8.0" bold="true">
                  <xsl:apply-templates select="$PatientInformation/PatientAge"/>
                </phrase>
              </cell>
              <cell borderwidth="0">
                <phrase font="Helvetica" size="8.0" bold="false">Gender</phrase>
              </cell>
              <cell borderwidth="0">
                <phrase font="Helvetica" size="8.0" bold="true">
                  <xsl:apply-templates select="$PatientInformation/Gender"></xsl:apply-templates>
                </phrase>
              </cell>
            </row>
            <row>
              <cell borderwidth="0" leftpadding="2.0">
                <phrase font="Helvetica" size="8.0" bold="false">ID Number</phrase>
              </cell>
              <cell borderwidth="0">
                <phrase font="Helvetica" size="8.0" bold="true">
                  <xsl:apply-templates select="$PatientInformation/IDNumber"/>
                </phrase>
              </cell>
              <cell borderwidth="0">
                <phrase font="Helvetica" size="8.0" bold="false">Mobile Number</phrase>
              </cell>
              <cell borderwidth="0">
                <phrase font="Helvetica" size="8.0" bold="true">
                  <xsl:apply-templates select="$PatientInformation/MobileNumber"></xsl:apply-templates>
                </phrase>
              </cell>
            </row>
            <row>
              <cell borderwidth="0" leftpadding="2.0">
                <phrase font="Helvetica" size="8.0" bold="false">Email Address</phrase>
              </cell>
              <cell borderwidth="0">
                <phrase font="Helvetica" size="8.0" bold="true">
                  <xsl:apply-templates select="$PatientInformation/EmailAddress"/>
                </phrase>
              </cell>
              <cell borderwidth="0">
                <phrase font="Helvetica" size="8.0" bold="false">Marital Status</phrase>
              </cell>
              <cell borderwidth="0">
                <phrase font="Helvetica" size="8.0" bold="true">
                  <xsl:apply-templates select="$PatientInformation/MaritalStatus"></xsl:apply-templates>
                </phrase>
              </cell>
            </row>
            <row>
              <cell borderwidth="0" leftpadding="2.0">
                <phrase font="Helvetica" size="8.0" bold="false">Preffered Contact Type</phrase>
              </cell>
              <cell borderwidth="0">
                <phrase font="Helvetica" size="8.0" bold="true">
                  <xsl:apply-templates select="$PatientInformation/PrefferedContactType"></xsl:apply-templates>
                </phrase>
              </cell>
              <cell borderwidth="0">
                <phrase font="Helvetica" size="8.0" bold="false">Source Of Discovery</phrase>
              </cell>
              <cell borderwidth="0">
                <phrase font="Helvetica" size="8.0" bold="true">
                  <xsl:apply-templates select="$PatientInformation/SourceOfDiscovery"/>
                </phrase>
              </cell>
            </row>
            <row>
              <cell borderwidth="0" leftpadding="2.0">
                <phrase font="Helvetica" size="8.0" bold="false">Physical Address</phrase>
              </cell>
              <cell borderwidth="0">
                <phrase font="Helvetica" size="8.0" bold="true" type="newlineseparator">
                  <xsl:apply-templates select="$PatientInformation/PhysicalAddress"></xsl:apply-templates>
                </phrase>
              </cell>
              <cell borderwidth="0">
                <phrase font="Helvetica" size="8.0" bold="false">Postal Address</phrase>
              </cell>
              <cell borderwidth="0">
                <phrase font="Helvetica" size="8.0" bold="true" type="newlineseparator">
                  <xsl:apply-templates select="$PatientInformation/PostalAddress"/>
                </phrase>
              </cell>
            </row>
          </table>

        </cell>

      </row>

    </table>

  </xsl:template>

  <xsl:template name="MedicalAidDetails">
    <xsl:param name="MedicalAidInformation"></xsl:param>
    <xsl:param name="MedicalAidDependancy"></xsl:param>

    <xsl:if test="$MedicalAidInformation/PatientMedicalAidInd = 1">

      <table columns="1" keeptogether="true" width="100.00">
        <row>
          <cell borderwidth="0" height="5.00">
            <phrase font="Helvetica" size="10.0" bold="false"></phrase>
          </cell>
        </row>
      </table>

      <table columns="1" widths="100.00" keeptogether="true" width="100.00">
        <row>
          <cell borderwidth="0.5">
            <table columns="4" keeptogether="true" width="100.00" widths="20,30,20,30">
              <row>
                <cell colspan="4" bottomborderwidth="0.5" height="25.0" indentation="5.0" leftborderwidth="0" rightborderwidth="0" topborderwidth="0">
                  <phrase font="Helvetica" size="12.0" bold="false" leading="0">Medical Aid Information</phrase>
                </cell>
              </row>
              <row>
                <cell borderwidth="0" leftpadding="2.0">
                  <phrase font="Helvetica" size="8.0" bold="false">Medical Aid Scheme</phrase>
                </cell>
                <cell borderwidth="0">
                  <phrase font="Helvetica" size="8.0" bold="true">
                    <xsl:apply-templates select="$MedicalAidInformation/MedicalAidName"/>
                  </phrase>
                </cell>
                <cell borderwidth="0" leftpadding="2.0">
                  <phrase font="Helvetica" size="8.0" bold="false">Plan Type</phrase>
                </cell>
                <cell borderwidth="0">
                  <phrase font="Helvetica" size="8.0" bold="true">
                    <xsl:apply-templates select="$MedicalAidInformation/MedicalAidScheme"></xsl:apply-templates>
                  </phrase>
                </cell>
              </row>
              <row>
                <cell borderwidth="0" leftpadding="2.0">
                  <phrase font="Helvetica" size="8.0" bold="false">Principal Member</phrase>
                </cell>
                <cell borderwidth="0">
                  <phrase font="Helvetica" size="8.0" bold="true">
                    <xsl:apply-templates select="$MedicalAidInformation/PrincipalMember"></xsl:apply-templates>
                  </phrase>
                </cell>
                <cell borderwidth="0" leftpadding="2.0">
                  <phrase font="Helvetica" size="8.0" bold="false">Medical Aid Number</phrase>
                </cell>
                <cell borderwidth="0">
                  <phrase font="Helvetica" size="8.0" bold="true">
                    <xsl:apply-templates select="$MedicalAidInformation/MedicalAidNumber"></xsl:apply-templates>
                  </phrase>
                </cell>
              </row>
              <xsl:for-each select="$MedicalAidDependancy">
                <row>
                  <cell borderwidth="0" leftpadding="2.0">
                    <phrase font="Helvetica" size="8.0" bold="false">Dependant Name</phrase>
                  </cell>
                  <cell borderwidth="0" colspan="2">
                    <phrase font="Helvetica" size="8.0" bold="true">
                      <xsl:apply-templates select="PatientMedicalAidDependancy"/>
                    </phrase>
                  </cell>
                  <cell borderwidth="0">
                    <phrase font="Helvetica" size="8.0" bold="true">
                      <xsl:apply-templates select="MedicalAidCode"></xsl:apply-templates>
                    </phrase>
                  </cell>
                </row>

              </xsl:for-each>
            </table>

          </cell>

        </row>

      </table>
    </xsl:if>

  </xsl:template>

  <xsl:template name="VitalSignDetails">
    <xsl:param name="PatientVitalSigns"></xsl:param>
    <xsl:param name="SurgeyInformation"></xsl:param>

    <xsl:if test="$SurgeyInformation/DoctorAccessInd = -1 or $SurgeyInformation/NurseAccessInd = -1">

      <table columns="1" keeptogether="true" width="100.00">
        <row>
          <cell borderwidth="0" height="8.00">
            <phrase font="Helvetica" size="10.0" bold="false"></phrase>
          </cell>
        </row>
      </table>

      <table columns="1" widths="100.00" keeptogether="true" width="100.00">
        <row>
          <cell borderwidth="0.5">
            <table columns="10" keeptogether="true" width="100.00" widths="10.00, 10.00, 10.00, 10.00, 10.00, 10.00, 10.00, 10.00, 10.00, 10.00" tabletype="full">
              <row>
                <cell colspan="10" bottomborderwidth="0.5" height="25.0" indentation="5.0" leftborderwidth="0" rightborderwidth="0" topborderwidth="0">
                  <phrase font="Helvetica" size="12.0" bold="false" leading="0">Vital Signs</phrase>
                </cell>
              </row>
              <row>
                <xsl:for-each select="$PatientVitalSigns">
                  <cell borderwidth="0" leftpadding="10.0">
                    <table columns="1" widths="100" width="100">
                      <row>
                        <cell borderwidth="0">
                          <phrase font="Helvetica" size="8.0" bold="false">
                            <xsl:apply-templates select="VitalSignName"/>
                          </phrase>
                        </cell>
                      </row>
                    </table>
                  </cell>
                  <cell borderwidth="0">
                    <table columns="1" widths="100" width="100">
                      <row>
                        <cell>
                          <phrase font="Helvetica" size="8.0" bold="false">
                            <xsl:apply-templates select="VitalSignValue"/>
                          </phrase>
                        </cell>
                      </row>
                    </table>
                  </cell>
                </xsl:for-each>
              </row>
            </table>

          </cell>

        </row>

      </table>

    </xsl:if>

  </xsl:template>

  <xsl:template name="MedicalNoteDetails">
    <xsl:param name="SurgeyInformation"></xsl:param>
    <xsl:param name="PatientChronicDeseases"></xsl:param>
    <xsl:param name="PatientDeseaseScreenings"></xsl:param>
    <xsl:param name="PatientPastMedicalHistories"></xsl:param>
    <xsl:param name="PatientMedicalNotes"></xsl:param>
    <xsl:param name="PatientClinicalExaminations"></xsl:param>
    <xsl:param name="PatientMedicalMonitoring"></xsl:param>

    <xsl:if test="$SurgeyInformation/DoctorAccessInd = -1">

      <table columns="1" keeptogether="true" width="100.00">
        <row>
          <cell borderwidth="0" height="8.00">
            <phrase font="Helvetica" size="10.0" bold="false"></phrase>
          </cell>
        </row>
      </table>

      <table columns="1" widths="100.00" keeptogether="false" width="100.00">
        <row>
          <cell bottomborderwidth="0" height="25.0" indentation="5.0" leftborderwidth="0.5" rightborderwidth="0.5" topborderwidth="0.5">
            <phrase font="Helvetica" size="12.0" bold="false" leading="0">Medical Notes</phrase>
          </cell>
        </row>
        <row>
          <cell rightpadding="3.0" leftpadding="3.0" borderwidth="0.5">
            <table columns="4" keeptogether="true" width="100.00" widths="25.00, 25.00, 25.00, 25.00">
              <row>
                <cell colspan="4" rightpadding="10.0" leftpadding="10.0" borderwidth="0">
                  <table columns="2" keeptogether="true" width="100.00" widths="50.00, 50.00">
                    <row>
                      <cell borderwidth="0.5" indentation="5.0">
                        <phrase font="Helvetica" size="8.0" bold="true">Chronic Disease</phrase>
                      </cell>
                      <cell borderwidth="0.5" indentation="5.0">
                        <phrase font="Helvetica" size="8.0" bold="true">Year Of Diagnoses</phrase>
                      </cell>
                    </row>
                    <xsl:for-each select="$PatientChronicDeseases">
                      <row>
                        <cell borderwidth="0.5" leftpadding="2.0">
                          <phrase font="Helvetica" size="8.0" bold="false">
                            <xsl:apply-templates select="Name"/>
                          </phrase>
                        </cell>
                        <cell borderwidth="0.5">
                          <phrase font="Helvetica" size="8.0" bold="false">
                            <xsl:apply-templates select="YearOfDiagnoses"/>
                          </phrase>
                        </cell>
                      </row>
                    </xsl:for-each>
                  </table>
                </cell>
              </row>
              <row>
                <cell colspan="4" rightpadding="10.0" leftpadding="10.0" borderwidth="0">
                  <table columns="2" keeptogether="true" width="100.00" widths="50.00, 50.00">
                    <row>
                      <cell borderwidth="0.5" indentation="5.0">
                        <phrase font="Helvetica" size="8.0" bold="true">Screened Disease</phrase>
                      </cell>
                      <cell borderwidth="0.5" indentation="5.0">
                        <phrase font="Helvetica" size="8.0" bold="true">Year Of Screening</phrase>
                      </cell>
                    </row>
                    <xsl:for-each select="$PatientDeseaseScreenings">
                      <row>
                        <cell borderwidth="0.5" leftpadding="2.0">
                          <phrase font="Helvetica" size="8.0" bold="false">
                            <xsl:apply-templates select="Name"/>
                          </phrase>
                        </cell>
                        <cell borderwidth="0.5">
                          <phrase font="Helvetica" size="8.0" bold="false">
                            <xsl:apply-templates select="YearOfScreening"/>
                          </phrase>
                        </cell>
                      </row>
                    </xsl:for-each>
                  </table>
                </cell>
              </row>
              <xsl:for-each select="$PatientPastMedicalHistories">
                <row>
                  <cell borderwidth="0" leftpadding="2.0" colspan="4" toppadding="3.0">
                    <phrase font="Helvetica" size="8.0" bold="true">
                      <xsl:apply-templates select="Name"/>
                    </phrase>
                  </cell>
                </row>
                <row>
                  <cell colspan="4" borderwidth="0.5" height="25.0" leftpadding="3.0">
                    <phrase font="Helvetica" size="8.0" bold="false">
                      <xsl:apply-templates select="Value"/>
                    </phrase>
                  </cell>
                </row>
              </xsl:for-each>
              <xsl:for-each select="$PatientMedicalNotes">
                <row>
                  <cell borderwidth="0" leftpadding="2.0" colspan="4" toppadding="3.0">
                    <phrase font="Helvetica" size="8.0" bold="true">
                      <xsl:apply-templates select="Name"/>
                    </phrase>
                  </cell>
                </row>
                <row>
                  <cell colspan="4" borderwidth="0.5" height="25.0" leftpadding="3.0">
                    <phrase font="Helvetica" size="8.0" bold="false">
                      <xsl:apply-templates select="Value"/>
                    </phrase>
                  </cell>
                </row>
              </xsl:for-each>
              <row>
                <xsl:for-each select="$PatientClinicalExaminations">
                  <cell colspan="2" rightpadding="2.0" leftpadding="2.0" toppadding="3.0" borderwidth="0">
                    <table columns="1" keeptogether="true" width="100.00" widths="100.00">
                      <row>
                        <cell borderwidth="0.5" height="15.0" indentation="5.0">
                          <phrase font="Helvetica" size="8.0" bold="true" leading="0">
                            <xsl:apply-templates select="Name"/>
                          </phrase>
                        </cell>
                      </row>
                      <row>
                        <cell height="30.0" borderwidth="0.5" leftpadding="3.0">
                          <phrase font="Helvetica" bold="false">
                            <xsl:apply-templates select="Value"/>
                          </phrase>
                        </cell>
                      </row>
                    </table>
                  </cell>
                </xsl:for-each>
              </row>
              <xsl:for-each select="$PatientMedicalMonitoring">
                <row>
                  <cell borderwidth="0" leftpadding="2.0" colspan="4" toppadding="3.0">
                    <phrase font="Helvetica" size="8.0" bold="true">
                      <xsl:apply-templates select="Name"/>
                    </phrase>
                  </cell>
                </row>
                <row>
                  <cell colspan="4" borderwidth="0.5" height="25.0" leftpadding="3.0">
                    <phrase font="Helvetica" size="8.0" bold="false">
                      <xsl:apply-templates select="Value"/>
                    </phrase>
                  </cell>
                </row>
              </xsl:for-each>
            </table>

          </cell>
        </row>
      </table>

    </xsl:if>

  </xsl:template>

</xsl:stylesheet>
