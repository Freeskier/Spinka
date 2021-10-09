using System.Collections.Generic;

namespace Spinka.Domain.Models
{
    public class Person : BaseEntity   
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Pesel { get; set; }
        public string Login { get; set; }
        public int OpNo { get; set; }
        public string PhoneNumber { get; set; }
        public virtual MilitaryRank MilitaryRank { get; set; }
        public int? MilitaryRankId { get; set; }
        public string Father { get; set; }

        private ISet<PersonAuthorization> _personAuthorizations = new HashSet<PersonAuthorization>();
        public IEnumerable<PersonAuthorization> PersonAuthorizations => _personAuthorizations;

        private ISet<TrainingGroupsPerson> _personInTrainingGroups = new HashSet<TrainingGroupsPerson>();
        public IEnumerable<TrainingGroupsPerson> PersonInTrainingGroups => _personInTrainingGroups;
        private ISet<AuxPersonForEduBlock> _auxPersons = new HashSet<AuxPersonForEduBlock>();
        public IEnumerable<AuxPersonForEduBlock> AuxPersons => _auxPersons;
        private ISet<DayRepGroupPerson> _dayRepGroupPersons = new HashSet<DayRepGroupPerson>();
        public IEnumerable<DayRepGroupPerson> DayRepGroupPersons => _dayRepGroupPersons;
        private ISet<PersonAuthorisedForEduBlockFunction> _personAuthorisedForEduBlockFunctions = new HashSet<PersonAuthorisedForEduBlockFunction>();
        public IEnumerable<PersonAuthorisedForEduBlockFunction> PersonAuthorisedForEduBlockFunctions => _personAuthorisedForEduBlockFunctions;
        
        private readonly ISet<AssignedPersonToMedicalService> _medicalStaff = new HashSet<AssignedPersonToMedicalService>();
        public IEnumerable<AssignedPersonToMedicalService> MedicalStaff => _medicalStaff;
        private ISet<AssignedAssistantInstructor> _assistantInstructors = new HashSet<AssignedAssistantInstructor>();
        public IEnumerable<AssignedAssistantInstructor> AssistantInstructors => _assistantInstructors;
        private ISet<EduBlockControl> _eduBlockControls = new HashSet<EduBlockControl>();
        public IEnumerable<EduBlockControl> EduBlockControls => _eduBlockControls;
        private ISet<AdditionalPersonnel> _additionalPersonnel = new HashSet<AdditionalPersonnel>();
        public IEnumerable<AdditionalPersonnel> AdditionalPersonnel => _additionalPersonnel;
    }
}