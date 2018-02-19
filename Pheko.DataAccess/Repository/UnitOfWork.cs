using Pheko.DataAccess.Enums;
using Pheko.DataAccess.Repository.Classes;
using Pheko.DataAccess.Utility;

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity.Validation;
using System.Data.SqlClient;

namespace Pheko.DataAccess.Repository
{
    public class UnitOfWork : IDisposable
    {
        #region Private Fields

        private PhekoEntities _Context;
        private bool _Disposed;
        
        private GenericRepository<Doctor> _DoctorRepository;
        private GenericRepository<Patient> _PatientRepository;
        private GenericRepository<PatientAddress> _PatientAddressRepository;
        private GenericRepository<PatientConsultation> _PatientConsultationRepository;
        private GenericRepository<PatientMedicalAidDependancy> _PatientMedicalAidDependancyRepository;
        private GenericRepository<PatientMedicalNote> _PatientMedicalNoteRepository;
        private GenericRepository<PatientVitalSign> _PatientVitalSign;
        private GenericRepository<Field> _FieldRepository;
        private GenericRepository<FieldValue> _FieldValueRepository;
        private GenericRepository<Country> _CountryRepository;
        private GenericRepository<Province> _ProvinceRepository;
        private GenericRepository<SecurityUser> _SecurityUserRepository;
        private GenericRepository<SecurityRole> _SecurityRoleRepository;
        private GenericRepository<SecurityUserRole> _SecurityUserRoleRepository;
        private GenericRepository<VitalSign> _VitalSignRepository;
        private GenericRepository<MedicalNote> _MedicalNoteRepository;
        private GenericRepository<ChronicDesease> _ChronicDeseaseRepository;
        private GenericRepository<PatientChronicDesease> _PatientChronicDeseaseRepository;
        private GenericRepository<PastMedicalHistory> _PastMedicalHistoryRepository;
        private GenericRepository<PatientPastMedicalHistory> _PatientPastMedicalHistoryRepository;
        private GenericRepository<DeseaseScreening> _DeseaseScreeningRepository;
        private GenericRepository<PatientDeseaseScreening> _PatientDeseaseScreeningRepository;
        private GenericRepository<ClinicalExamination> _ClinicalExaminationRepository;
        private GenericRepository<PatientClinicalExamination> _PatientClinicalExaminationRepository;
        private GenericRepository<MedicalMonitoring> _MedicalMonitoringRepository;
        private GenericRepository<PatientMedicalMonitoring> _PatientMedicalMonitoringRepository;
        private GenericRepository<PatientConsultationSickNote> _PatientConsultationSickNoteRepository;

        #endregion

        public UnitOfWork()
        {
            _Context = new PhekoEntities();
            _Disposed = false;
        }

        #region Public Properties 

        public GenericRepository<PatientVitalSign> PatientVitalSignRepository
        {
            get
            {
                if (this._PatientVitalSign == null)
                {
                    this._PatientVitalSign = new GenericRepository<PatientVitalSign>(_Context);
                }

                return _PatientVitalSign;
            }
        }

        public GenericRepository<Doctor> DoctorRepository
        {
            get
            {
                if (this._DoctorRepository == null)
                {
                    this._DoctorRepository = new GenericRepository<Doctor>(_Context);
                }

                return _DoctorRepository;
            }
        }

        public GenericRepository<PatientConsultation> PatientConsultationRepository
        {
            get
            {
                if (this._PatientConsultationRepository == null)
                {
                    this._PatientConsultationRepository = new GenericRepository<PatientConsultation>(_Context);
                }

                return _PatientConsultationRepository;
            }
        }

        public GenericRepository<Patient> PatientRepository
        {
            get
            {
                if (this._PatientRepository == null)
                {
                    this._PatientRepository = new GenericRepository<Patient>(_Context);
                }

                return _PatientRepository;
            }
        }

        public GenericRepository<PatientAddress> PatientAddressRepository
        {
            get
            {
                if (this._PatientAddressRepository == null)
                {
                    this._PatientAddressRepository = new GenericRepository<PatientAddress>(_Context);
                }

                return _PatientAddressRepository;
            }
        }

        public GenericRepository<PatientMedicalAidDependancy> PatientMedicalAidDependancyRepository
        {
            get
            {
                if (this._PatientMedicalAidDependancyRepository == null)
                {
                    this._PatientMedicalAidDependancyRepository = new GenericRepository<PatientMedicalAidDependancy>(_Context);
                }

                return _PatientMedicalAidDependancyRepository;
            }
        }

        public GenericRepository<PatientMedicalNote> PatientMedicalNoteRepository
        {
            get
            {
                if (this._PatientMedicalNoteRepository == null)
                {
                    this._PatientMedicalNoteRepository = new GenericRepository<PatientMedicalNote>(_Context);
                }

                return _PatientMedicalNoteRepository;
            }
        }

        public GenericRepository<Field> FieldRepository
        {
            get
            {
                if (this._FieldRepository == null)
                {
                    this._FieldRepository = new GenericRepository<Field>(_Context);
                }

                return _FieldRepository;
            }
        }

        public GenericRepository<FieldValue> FieldValueRepository
        {
            get
            {
                if (this._FieldValueRepository == null)
                {
                    this._FieldValueRepository = new GenericRepository<FieldValue>(_Context);
                }

                return _FieldValueRepository;
            }
        }

        public GenericRepository<Country> CountryRepository
        {
            get
            {
                if (this._CountryRepository == null)
                {
                    this._CountryRepository = new GenericRepository<Country>(_Context);
                }

                return _CountryRepository;
            }
        }

        public GenericRepository<Province> ProvinceRepository
        {
            get
            {
                if (this._ProvinceRepository == null)
                {
                    this._ProvinceRepository = new GenericRepository<Province>(_Context);
                }

                return _ProvinceRepository;
            }
        }

        public GenericRepository<SecurityUser> SecurityUserRepository
        {
            get
            {
                if (this._SecurityUserRepository == null)
                {
                    this._SecurityUserRepository = new GenericRepository<SecurityUser>(_Context);
                }

                return _SecurityUserRepository;
            }
        }

        public GenericRepository<SecurityRole> SecurityRoleRepository
        {
            get
            {
                if (this._SecurityRoleRepository == null)
                {
                    this._SecurityRoleRepository = new GenericRepository<SecurityRole>(_Context);
                }

                return _SecurityRoleRepository;
            }
        }

        public GenericRepository<SecurityUserRole> SecurityUserRoleRepository
        {
            get
            {
                if (this._SecurityUserRoleRepository == null)
                {
                    this._SecurityUserRoleRepository = new GenericRepository<SecurityUserRole>(_Context);
                }

                return _SecurityUserRoleRepository;
            }
        }

        public GenericRepository<VitalSign> VitalSignRepository
        {
            get
            {
                if (this._VitalSignRepository == null)
                {
                    this._VitalSignRepository = new GenericRepository<VitalSign>(_Context);
                }

                return _VitalSignRepository;
            }
        }

        public GenericRepository<MedicalNote> MedicalNoteRepository
        {
            get
            {
                if (this._MedicalNoteRepository == null)
                {
                    this._MedicalNoteRepository = new GenericRepository<MedicalNote>(_Context);
                }

                return _MedicalNoteRepository;
            }
        }

        public GenericRepository<ChronicDesease> ChronicDeseaseRepository
        {
            get
            {
                if (this._ChronicDeseaseRepository == null)
                {
                    this._ChronicDeseaseRepository = new GenericRepository<ChronicDesease>(_Context);
                }

                return _ChronicDeseaseRepository;
            }
        }

        public GenericRepository<PatientChronicDesease> PatientChronicDeseaseRepository
        {
            get
            {
                if (this._PatientChronicDeseaseRepository == null)
                {
                    this._PatientChronicDeseaseRepository = new GenericRepository<PatientChronicDesease>(_Context);
                }

                return _PatientChronicDeseaseRepository;
            }
        }

        public GenericRepository<PastMedicalHistory> PastMedicalHistoryRepository
        {
            get
            {
                if (this._PastMedicalHistoryRepository == null)
                {
                    this._PastMedicalHistoryRepository = new GenericRepository<PastMedicalHistory>(_Context);
                }

                return _PastMedicalHistoryRepository;
            }
        }

        public GenericRepository<PatientPastMedicalHistory> PatientPastMedicalHistoryRepository
        {
            get
            {
                if (this._PatientPastMedicalHistoryRepository == null)
                {
                    this._PatientPastMedicalHistoryRepository = new GenericRepository<PatientPastMedicalHistory>(_Context);
                }

                return _PatientPastMedicalHistoryRepository;
            }
        }

        public GenericRepository<DeseaseScreening> DeseaseScreeningRepository
        {
            get
            {
                if (this._DeseaseScreeningRepository == null)
                {
                    this._DeseaseScreeningRepository = new GenericRepository<DeseaseScreening>(_Context);
                }

                return _DeseaseScreeningRepository;
            }
        }

        public GenericRepository<PatientDeseaseScreening> PatientDeseaseScreeningRepository
        {
            get
            {
                if (this._PatientDeseaseScreeningRepository == null)
                {
                    this._PatientDeseaseScreeningRepository = new GenericRepository<PatientDeseaseScreening>(_Context);
                }

                return _PatientDeseaseScreeningRepository;
            }
        }

        public GenericRepository<ClinicalExamination> ClinicalExaminationRepository
        {
            get
            {
                if (this._ClinicalExaminationRepository == null)
                {
                    this._ClinicalExaminationRepository = new GenericRepository<ClinicalExamination>(_Context);
                }

                return _ClinicalExaminationRepository;
            }
        }

        public GenericRepository<PatientClinicalExamination> PatientClinicalExaminationRepository
        {
            get
            {
                if (this._PatientClinicalExaminationRepository == null)
                {
                    this._PatientClinicalExaminationRepository = new GenericRepository<PatientClinicalExamination>(_Context);
                }

                return _PatientClinicalExaminationRepository;
            }
        }

        public GenericRepository<MedicalMonitoring> MedicalMonitoringRepository
        {
            get
            {
                if (this._MedicalMonitoringRepository == null)
                {
                    this._MedicalMonitoringRepository = new GenericRepository<MedicalMonitoring>(_Context);
                }

                return _MedicalMonitoringRepository;
            }
        }

        public GenericRepository<PatientMedicalMonitoring> PatientMedicalMonitoringRepository
        {
            get
            {
                if (this._PatientMedicalMonitoringRepository == null)
                {
                    this._PatientMedicalMonitoringRepository = new GenericRepository<PatientMedicalMonitoring>(_Context);
                }

                return _PatientMedicalMonitoringRepository;
            }
        }

        public GenericRepository<PatientConsultationSickNote> PatientConsultationSickNoteRepository
        {
            get
            {
                if (this._PatientConsultationSickNoteRepository == null)
                {
                    this._PatientConsultationSickNoteRepository = new GenericRepository<PatientConsultationSickNote>(_Context);
                }

                return _PatientConsultationSickNoteRepository;
            }
        }

        #endregion

        public void Save()
        {
            try
            {
                _Context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var eve in ex.EntityValidationErrors)
                {
                }
                throw ex;
            }

        }

        public bool AutoDetectChanges
        {
            get
            {
                return _Context.Configuration.AutoDetectChangesEnabled;
            }
            set
            {
                _Context.Configuration.AutoDetectChangesEnabled = value;
            }
        }

        public bool ValidateOnSave
        {
            get
            {
                return _Context.Configuration.ValidateOnSaveEnabled;
            }
            set
            {
                _Context.Configuration.ValidateOnSaveEnabled = value;
            }
        }

        public DataSet DataSetExecuteStoredProcedure(string storedProcedureName, List<Parameter> parameters)
        {
            DataSet dataset = new DataSet();

            using (_Context.Database.Connection)
            {
                if (_Context.Database.Connection.State == ConnectionState.Closed)
                {
                    _Context.Database.Connection.Open();
                }

                DbCommand cmd = _Context.Database.Connection.CreateCommand();

                cmd.CommandText = storedProcedureName;
                cmd.CommandType = CommandType.StoredProcedure;

                foreach (Parameter parameter in parameters)
                {
                    cmd.Parameters.Add(SetParameter(parameter));
                }

                DbProviderFactory factory = DbProviderFactories.GetFactory(_Context.Database.Connection);
                DbDataAdapter sqlDataAdapter = factory.CreateDataAdapter();

                sqlDataAdapter.SelectCommand = cmd;
                sqlDataAdapter.Fill(dataset);
            }

            return dataset;
        }

        private SqlParameter SetParameter(Parameter parameter)
        {
            switch (parameter.ParameterType)
            {
                case ParameterType.INT:
                    return new SqlParameter() { DbType = DbType.Int32, ParameterName = parameter.Name, Value = DbConverter.ToDbInteger(parameter.Value) };
                case ParameterType.VARCHAR:
                case ParameterType.NVARCHAR:
                case ParameterType.TEXT:
                    return new SqlParameter() { DbType = DbType.String, Size = parameter.Size, ParameterName = parameter.Name, Value = DbConverter.ToDbString(parameter.Value) };
                case ParameterType.MONEY:
                    return new SqlParameter() { DbType = DbType.Currency, ParameterName = parameter.Name, Value = DbConverter.ToDbDecimal(parameter.Value) };
                case ParameterType.DECIMAL:
                    return new SqlParameter() { DbType = DbType.Decimal, ParameterName = parameter.Name, Value = DbConverter.ToDbDecimal(parameter.Value) };
                case ParameterType.GUID:
                    return new SqlParameter() { DbType = DbType.Guid, ParameterName = parameter.Name, Value = DbConverter.ToDbGuid(parameter.Value) };
                default:
                    throw new Exception("unknown parameter type.");
            }
        }
        
        protected virtual void Dispose(bool disposing)
        {
            if (!this._Disposed)
            {
                if (disposing)
                {
                    _Context.Dispose();
                }
            }

            this._Disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
