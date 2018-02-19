using Itextsharp.CustomXmlToPdfWriter;

using Pheko.WebPresentation.ServiceHandlers.Classes;

using System;
using System.Data;
using System.IO;
using System.Web;

namespace Pheko.WebPresentation.PdfDocuments
{
    public class PatientSchedule
    {
        public static string CreatePatientSchedulePdf(int patientId, int userId, string xsltDirectory, string tempDirectory,
                                                      bool canAccessVitalSigns, bool canAccessMedicalNote, HttpContextBase context)
        {
            string pdfFileName = tempDirectory + Guid.NewGuid().ToString() + ".pdf";
            DocumentScheduleHandler documentScheduleHandler = new DocumentScheduleHandler();
            DataSet patientDetailsDataSet = documentScheduleHandler.GetPatientSchedule(patientId, userId);

            patientDetailsDataSet.DataSetName = "PatientSchedule";
            patientDetailsDataSet.Tables[0].TableName = "Surgery";
            patientDetailsDataSet.Tables[1].TableName = "PatientDetails";
            patientDetailsDataSet.Tables[2].TableName = "MedicalAidDetails";

            if (canAccessVitalSigns)
            {
                patientDetailsDataSet.Tables[3].TableName = "PatientVitalSigns";

                if (canAccessMedicalNote)
                {
                    patientDetailsDataSet.Tables[4].TableName = "PatientChronicDeseases";
                    patientDetailsDataSet.Tables[5].TableName = "PatientDeseaseScreenings";
                    patientDetailsDataSet.Tables[6].TableName = "PatientPastMedicalHistories";
                    patientDetailsDataSet.Tables[7].TableName = "PatientMedicalNotes";
                    patientDetailsDataSet.Tables[8].TableName = "PatientClinicalExaminations";
                    patientDetailsDataSet.Tables[9].TableName = "PatientMedicalMonitoring";
                }
            }

            DataRow dataRow = patientDetailsDataSet.Tables[0].Rows[0];

            dataRow["Logo"] = context.Server.MapPath(dataRow["Logo"].ToString());

            XmlPdfWriter.WritePdf(patientDetailsDataSet, xsltDirectory + "PateintDetails.xslt", pdfFileName);

            return pdfFileName;
        }

        public static void CreatePatientSchedulePdf(int patientId, int userId, string xsltDirectory, bool canAccessVitalSigns,
                                                    bool canAccessMedicalNote, HttpContextBase context, MemoryStream memoryStream)
        {
            DocumentScheduleHandler documentScheduleHandler = new DocumentScheduleHandler();
            DataSet patientDetailsDataSet = documentScheduleHandler.GetPatientSchedule(patientId, userId);

            patientDetailsDataSet.DataSetName = "PatientSchedule";
            patientDetailsDataSet.Tables[0].TableName = "Surgery";
            patientDetailsDataSet.Tables[1].TableName = "PatientDetails";
            patientDetailsDataSet.Tables[2].TableName = "MedicalAidDetails";

            if (canAccessVitalSigns)
            {
                patientDetailsDataSet.Tables[3].TableName = "PatientVitalSigns";

                if (canAccessMedicalNote)
                {
                    patientDetailsDataSet.Tables[4].TableName = "PatientChronicDeseases";
                    patientDetailsDataSet.Tables[5].TableName = "PatientDeseaseScreenings";
                    patientDetailsDataSet.Tables[6].TableName = "PatientPastMedicalHistories";
                    patientDetailsDataSet.Tables[7].TableName = "PatientMedicalNotes";
                    patientDetailsDataSet.Tables[8].TableName = "PatientClinicalExaminations";
                    patientDetailsDataSet.Tables[9].TableName = "PatientMedicalMonitoring";
                }
            }

            DataRow dataRow = patientDetailsDataSet.Tables[0].Rows[0];

            dataRow["Logo"] = context.Server.MapPath(dataRow["Logo"].ToString());

            XmlPdfWriter.WritePdf(patientDetailsDataSet, xsltDirectory + "PateintDetails.xslt", memoryStream);
        }
    }
}
