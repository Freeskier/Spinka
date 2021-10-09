-- Tables

-- MR
CREATE TABLE [dbo].[1MiscReports](
	[ID] [int] NOT NULL,
	[PlanZajec] [nchar](10) NULL,
	[LimityAdmin] [nchar](10) NULL,
	[ZatwierdzanieZajec] [nchar](10) NULL,
	[MedykAdmin] [nchar](10) NULL,
	[UprawnieniaID] [int] NULL,
 CONSTRAINT [PK_RaportyDzienne] PRIMARY KEY CLUSTERED 

-- AU
 CREATE TABLE [dbo].[AmountUnits](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Accronym] [nvarchar](5) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_JednostkiMiary] PRIMARY KEY CLUSTERED 

-----------------------------TWFK---------------------------------------------
-- ATF
 CREATE TABLE [dbo].[AssignedTrainingFacilities](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TrainingFacilitiesId] [int] NOT NULL,
	[ClassesId] [int] NOT NULL,
	[StartTime] [datetime] NOT NULL,
	[EndTime] [datetime] NOT NULL,
	[ApprovedByPersonnelId] [int] NULL,
	[IsDeleted] [bit] NOT NULL,
	[Notes] [nvarchar](250) NULL,
	[ApprovedDateTime] [datetime] NULL,
 CONSTRAINT [PK_PrzydzielanieObiektySzkoleniowe] PRIMARY KEY CLUSTERED 

-------------------------------FK---------------------------------------------
-- ATF -> TF
ALTER TABLE [dbo].[AssignedTrainingFacilities]  WITH CHECK ADD  CONSTRAINT [FK_PrzydzielanieObiektySzkoleniowe_ObiektySzkoleniowe] FOREIGN KEY([TrainingFacilitiesId])
REFERENCES [dbo].[TrainingFacilities] ([Id])

-- ATF -> C
ALTER TABLE [dbo].[AssignedTrainingFacilities]  WITH CHECK ADD  CONSTRAINT [FK_PrzydzielanieObiektySzkoleniowe_Zajecia] FOREIGN KEY([ClassesId])
REFERENCES [dbo].[Classes] ([Id])
-------------------------------FK---------------------------------------------

-- AT
 CREATE TABLE [dbo].[AuthorisationsTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](15) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Funkcje] PRIMARY KEY CLUSTERED 

-----------------------------TWFK---------------------------------------------
-- APFC
 CREATE TABLE [dbo].[AuxPersonnelForClasses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ConvoyComPersonnelId] [int] NULL,
	[DriverPersonnelId] [int] NULL,
	[Vehicle] [int] NULL,
	[Comms] [nvarchar](100) NULL,
	[SecurityPersonnelId1] [int] NULL,
	[SecurityPersonnelId2] [int] NULL,
	[SecurityPersonnelId3] [int] NULL,
	[SecurityPersonnelId4] [int] NULL,
	[SecurityPersonnelId5] [int] NULL,
	[SecurityPersonnelId6] [int] NULL,
	[SecurityPersonnelId7] [int] NULL,
	[SecurityPersonnelId8] [int] NULL,
	[SecurityPersonnelId9] [int] NULL,
	[SecurityPersonnelId10] [int] NULL,
	[SecurityPersonnelId11] [int] NULL,
 CONSTRAINT [PK_UbezpieczenieZajec] PRIMARY KEY CLUSTERED

-------------------------------FK---------------------------------------------
-- APFC -> V
ALTER TABLE [dbo].[AuxPersonnelForClasses]  WITH CHECK ADD  CONSTRAINT [FK_UbezpieczenieZajec_Pojazd] FOREIGN KEY([Vehicle])
REFERENCES [dbo].[Vehicles] ([Id])
-------------------------------FK---------------------------------------------

-----------------------------TWFK---------------------------------------------
-- C
 CREATE TABLE [dbo].[Classes](
	[Id] [int] NOT NULL,
	[StartDateTime] [datetime] NOT NULL,
	[EndDateTime] [datetime] NOT NULL,
	[TrainingFacilitiesId] [int] NOT NULL,
	[InstructorPersonnelId] [int] NOT NULL,
	[OrdnanceManagerPersonnelId] [int] NULL,
	[ClassesSubjectsId] [int] NOT NULL,
	[TrainingGroupsID] [int] NOT NULL,
	[LastUpdateDateTime] [datetime] NULL,
	[LastUpdatePersonnelId] [int] NULL,
	[CreatedByPersonnelId] [int] NOT NULL,
	[ConvoyVehicleId] [int] NULL,
	[DriverPersonnelId] [int] NULL,
	[ShootingInstructorPersonnelId] [int] NULL,
	[MedicalServiceForClassesId] [int] NULL,
	[AuxPersonnelForClassesId] [int] NULL,
	[ExplosivesManagerPersonnelId] [int] NULL,
	[SecurityPersonnelId1] [int] NULL,
	[SecurityPersonnelId2] [int] NULL,
	[SecurityPersonnelId3] [int] NULL,
	[SecurityPersonnelId4] [int] NULL,
	[ParamedicPersonnelId] [int] NULL,
	[IsDeleted] [bit] NOT NULL,
	[OriginalClassesId] [int] NULL,
	[Approved] [bit] NULL,
	[ApprovedByPersonnelId] [int] NULL,
	[ApprovedDateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_Zajecia] PRIMARY KEY CLUSTERED

-------------------------------FK---------------------------------------------
-- C -> TG
ALTER TABLE [dbo].[Classes]  WITH CHECK ADD  CONSTRAINT [FK_Zajecia_GrupySzkoleniowe] FOREIGN KEY([TrainingGroupsID])
REFERENCES [dbo].[TrainingGroups] ([Id])

-- c -> P
ALTER TABLE [dbo].[Classes]  WITH CHECK ADD  CONSTRAINT [FK_Zajecia_Osoby] FOREIGN KEY([InstructorPersonnelId])
REFERENCES [dbo].[Personnel] ([ID])

-- C -> P
ALTER TABLE [dbo].[Classes]  WITH CHECK ADD  CONSTRAINT [FK_Zajecia_Osoby1] FOREIGN KEY([OrdnanceManagerPersonnelId])
REFERENCES [dbo].[Personnel] ([ID])

-- C -> P
ALTER TABLE [dbo].[Classes]  WITH CHECK ADD  CONSTRAINT [FK_Zajecia_Osoby10] FOREIGN KEY([SecurityPersonnelId2])
REFERENCES [dbo].[Personnel] ([ID])

-- C -> P
ALTER TABLE [dbo].[Classes]  WITH CHECK ADD  CONSTRAINT [FK_Zajecia_Osoby11] FOREIGN KEY([SecurityPersonnelId3])
REFERENCES [dbo].[Personnel] ([ID])

-- C -> P
ALTER TABLE [dbo].[Classes]  WITH CHECK ADD  CONSTRAINT [FK_Zajecia_Osoby12] FOREIGN KEY([SecurityPersonnelId4])
REFERENCES [dbo].[Personnel] ([ID])

-- C -> P
ALTER TABLE [dbo].[Classes]  WITH CHECK ADD  CONSTRAINT [FK_Zajecia_Osoby13] FOREIGN KEY([ParamedicPersonnelId])
REFERENCES [dbo].[Personnel] ([ID])

-- C -> P
ALTER TABLE [dbo].[Classes]  WITH CHECK ADD  CONSTRAINT [FK_Zajecia_Osoby14] FOREIGN KEY([ApprovedByPersonnelId])
REFERENCES [dbo].[Personnel] ([ID])

-- C -> P
ALTER TABLE [dbo].[Classes]  WITH CHECK ADD  CONSTRAINT [FK_Zajecia_Osoby2] FOREIGN KEY([InstructorPersonnelId])
REFERENCES [dbo].[Personnel] ([ID])

-- C -> P
ALTER TABLE [dbo].[Classes]  WITH CHECK ADD  CONSTRAINT [FK_Zajecia_Osoby3] FOREIGN KEY([OrdnanceManagerPersonnelId])
REFERENCES [dbo].[Personnel] ([ID])

-- C -> P
ALTER TABLE [dbo].[Classes]  WITH CHECK ADD  CONSTRAINT [FK_Zajecia_Osoby4] FOREIGN KEY([ClassesSubjectsId])
REFERENCES [dbo].[Personnel] ([ID])

-- C -> P
ALTER TABLE [dbo].[Classes]  WITH CHECK ADD  CONSTRAINT [FK_Zajecia_Osoby5] FOREIGN KEY([LastUpdatePersonnelId])
REFERENCES [dbo].[Personnel] ([ID])

-- C -> P
ALTER TABLE [dbo].[Classes]  WITH CHECK ADD  CONSTRAINT [FK_Zajecia_Osoby6] FOREIGN KEY([CreatedByPersonnelId])
REFERENCES [dbo].[Personnel] ([ID])

-- C -> P
ALTER TABLE [dbo].[Classes]  WITH CHECK ADD  CONSTRAINT [FK_Zajecia_Osoby7] FOREIGN KEY([DriverPersonnelId])
REFERENCES [dbo].[Personnel] ([ID])

-- C -> P
ALTER TABLE [dbo].[Classes]  WITH CHECK ADD  CONSTRAINT [FK_Zajecia_Osoby8] FOREIGN KEY([ShootingInstructorPersonnelId])
REFERENCES [dbo].[Personnel] ([ID])

-- C -> P
ALTER TABLE [dbo].[Classes]  WITH CHECK ADD  CONSTRAINT [FK_Zajecia_Osoby9] FOREIGN KEY([SecurityPersonnelId1])
REFERENCES [dbo].[Personnel] ([ID])

-- C -> V
ALTER TABLE [dbo].[Classes]  WITH CHECK ADD  CONSTRAINT [FK_Zajecia_Pojazd1] FOREIGN KEY([ConvoyVehicleId])
REFERENCES [dbo].[Vehicles] ([Id])

-- C -> CS
ALTER TABLE [dbo].[Classes]  WITH CHECK ADD  CONSTRAINT [FK_Zajecia_TematyPrzedmiotowSzkolenia] FOREIGN KEY([ClassesSubjectsId])
REFERENCES [dbo].[ClassesSubjects] ([ID])

-- C -> MSFC
ALTER TABLE [dbo].[Classes]  WITH CHECK ADD  CONSTRAINT [FK_Zajecia_ZabezpieczenieMedyczne] FOREIGN KEY([MedicalServiceForClassesId])
REFERENCES [dbo].[MedicalServiceForClasses] ([Id])
-------------------------------FK---------------------------------------------

-- CS
 CREATE TABLE [dbo].[ClassesSubjects](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TrainingAreasId] [int] NOT NULL,
	[Subject] [nvarchar](250) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[IsSelected] [bit] NOT NULL,
	[IsMedicalServiceRequired] [bit] NOT NULL,
 CONSTRAINT [PK_TematyPrzedmiotowSzkolenia] PRIMARY KEY CLUSTERED 

-----------------------------TWFK---------------------------------------------
-- COLFD
 CREATE TABLE [dbo].[CurrentOrdnanceLimitsForDepartments](
	[Id] [int] NOT NULL,
	[UnitDepartmentId] [int] NOT NULL,
	[OrdnanceId] [int] NOT NULL,
	[Amount] [int] NOT NULL,
	[UpdateDateTime] [datetime] NOT NULL
) ON [PRIMARY]

-------------------------------FK---------------------------------------------
-- COLFD -> UD
ALTER TABLE [dbo].[CurrentOrdnanceLimitsForDepartments]  WITH CHECK ADD  CONSTRAINT [FK_AktualnyStanSrodkowBojowychWKomorkachJW_KomorkiJW] FOREIGN KEY([UnitDepartmentId])
REFERENCES [dbo].[UnitsDepartments] ([Id])

-- COLFD -> O
ALTER TABLE [dbo].[CurrentOrdnanceLimitsForDepartments]  WITH CHECK ADD  CONSTRAINT [FK_AktualnyStanSrodkowBojowychWKomorkachJW_SrodkiBojowe] FOREIGN KEY([OrdnanceId])
REFERENCES [dbo].[Ordnance] ([Id])
-------------------------------FK---------------------------------------------

-----------------------------TWFK---------------------------------------------
-- DR
CREATE TABLE [dbo].[DayReps](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Day] [datetime] NOT NULL,
	[DayrepsAccronymsId] [int] NOT NULL,
	[PersonnelId] [int] NOT NULL,
	[InputByPersonnelId] [int] NOT NULL,
	[Description] [nvarchar](50) NULL,
	[Location] [nvarchar](50) NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Dane] PRIMARY KEY CLUSTERED 

-------------------------------FK---------------------------------------------
 -- DR -> P
ALTER TABLE [dbo].[DayReps]  WITH CHECK ADD  CONSTRAINT [FK_Dane_Osoby] FOREIGN KEY([PersonnelId])
REFERENCES [dbo].[Personnel] ([ID])

-- DR -> PA
ALTER TABLE [dbo].[DayReps]  WITH CHECK ADD  CONSTRAINT [FK_Dane_UprawnieniaOsoby] FOREIGN KEY([InputByPersonnelId])
REFERENCES [dbo].[PersonnelAuthorisations] ([Id])

-- DR -> DRA
ALTER TABLE [dbo].[DayReps]  WITH CHECK ADD  CONSTRAINT [FK_Dane_Zmienne] FOREIGN KEY([DayrepsAccronymsId])
REFERENCES [dbo].[DayRepsAccronyms] ([Id])
-------------------------------FK---------------------------------------------

-- DRA
 CREATE TABLE [dbo].[DayRepsAccronyms](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](4) NOT NULL,
	[ShortDescription] [nvarchar](25) NOT NULL,
	[Color] [nchar](8) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[IsDescriptionRequired] [bit] NOT NULL,
 CONSTRAINT [PK_Zmienne] PRIMARY KEY CLUSTERED 

-----------------------------TWFK---------------------------------------------
-- DRGP
 CREATE TABLE [dbo].[DayRepsGroupsPersonnel](
	[Id] [int] NOT NULL,
	[PersonnelId] [int] NOT NULL,
	[GroupsForDayReps] [int] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_OsobyWGrupachRaportDzienny] PRIMARY KEY CLUSTERED

-------------------------------FK---------------------------------------------
 -- DRGP -> GFDR
ALTER TABLE [dbo].[DayRepsGroupsPersonnel]  WITH CHECK ADD  CONSTRAINT [FK_OsobyWGrupachRaportDzienny_GrupyWRaportowDziennych] FOREIGN KEY([GroupsForDayReps])
REFERENCES [dbo].[GroupsForDayReps] ([Id])

-- DRGP -> P
ALTER TABLE [dbo].[DayRepsGroupsPersonnel]  WITH CHECK ADD  CONSTRAINT [FK_OsobyWGrupachRaportDzienny_Osoby] FOREIGN KEY([PersonnelId])
REFERENCES [dbo].[Personnel] ([ID])
-------------------------------FK---------------------------------------------

-- FFC
 CREATE TABLE [dbo].[FunctionsForClasses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_FunkcjeNaZajeciach] PRIMARY KEY CLUSTERED

-- GFDR
 CREATE TABLE [dbo].[GroupsForDayReps](
	[Id] [int] NOT NULL,
	[Nazwa] [nvarchar](20) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_GrupyWRaportowDziennych] PRIMARY KEY CLUSTERED 

-----------------------------TWFK---------------------------------------------
-- GIC
 CREATE TABLE [dbo].[GroupsInClasses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClassesId] [int] NOT NULL,
	[TraininGroupsId] [int] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_GrupyNaZajeciach] PRIMARY KEY CLUSTERED

-------------------------------FK---------------------------------------------
-- GIC -> C
ALTER TABLE [dbo].[GroupsInClasses]  WITH CHECK ADD  CONSTRAINT [FK_GrupyNaZajeciach_Zajecia] FOREIGN KEY([ClassesId])
REFERENCES [dbo].[Classes] ([Id])
-------------------------------FK---------------------------------------------

-- GOO
 CREATE TABLE [dbo].[GroupsOfOrdnance](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_GrupySrodkowBojowych] PRIMARY KEY CLUSTERED

-----------------------------TWFK---------------------------------------------
-- MSFC
 CREATE TABLE [dbo].[MedicalServiceForClasses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ParamedicPersonnelId] [int] NULL,
	[DoctorPersonnelId] [int] NULL,
	[DriverPersonnelId] [int] NULL,
	[AmbulanceVehiclesId] [int] NULL,
 CONSTRAINT [PK_ZabezpieczenieMedyczne] PRIMARY KEY CLUSTERED

-------------------------------FK---------------------------------------------
-- MSFC -> P
ALTER TABLE [dbo].[MedicalServiceForClasses]  WITH CHECK ADD  CONSTRAINT [FK_ZabezpieczenieMedyczne_Osoby1] FOREIGN KEY([ParamedicPersonnelId])
REFERENCES [dbo].[Personnel] ([ID])

-- MSFC -> P
ALTER TABLE [dbo].[MedicalServiceForClasses]  WITH CHECK ADD  CONSTRAINT [FK_ZabezpieczenieMedyczne_Osoby2] FOREIGN KEY([DoctorPersonnelId])
REFERENCES [dbo].[Personnel] ([ID])

-- MSFC -> P
ALTER TABLE [dbo].[MedicalServiceForClasses]  WITH CHECK ADD  CONSTRAINT [FK_ZabezpieczenieMedyczne_Osoby3] FOREIGN KEY([DriverPersonnelId])
REFERENCES [dbo].[Personnel] ([ID])

-- MSFC -> V
ALTER TABLE [dbo].[MedicalServiceForClasses]  WITH CHECK ADD  CONSTRAINT [FK_ZabezpieczenieMedyczne_Pojazd] FOREIGN KEY([AmbulanceVehiclesId])
REFERENCES [dbo].[Vehicles] ([Id])
-------------------------------FK---------------------------------------------

-- MR
 CREATE TABLE [dbo].[MilitaryRanks](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RanksOrder] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Accronym] [varchar](15) NOT NULL,
	[NATO] [nvarchar](4) NOT NULL,
 CONSTRAINT [PK_StopnieWojskowe] PRIMARY KEY CLUSTERED 

-----------------------------TWFK---------------------------------------------
-- O
 CREATE TABLE [dbo].[Ordnance](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[LogIndex] [nchar](13) NOT NULL,
	[MeasureUnitId] [int] NOT NULL,
	[GroupsOfOrdnanceId] [int] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[IsDangerous] [bit] NOT NULL,
 CONSTRAINT [PK_SrodkiBojowe] PRIMARY KEY CLUSTERED 

-------------------------------FK---------------------------------------------
-- O -> GOO
ALTER TABLE [dbo].[Ordnance]  WITH CHECK ADD  CONSTRAINT [FK_SrodkiBojowe_GrupySrodkowBojowych] FOREIGN KEY([GroupsOfOrdnanceId])
REFERENCES [dbo].[GroupsOfOrdnance] ([Id])

-- O -> AU
ALTER TABLE [dbo].[Ordnance]  WITH CHECK ADD  CONSTRAINT [FK_SrodkiBojowe_JednostkiMiary] FOREIGN KEY([MeasureUnitId])
REFERENCES [dbo].[AmountUnits] ([Id])
-------------------------------FK---------------------------------------------

-----------------------------TWFK---------------------------------------------
-- OAFTF
 CREATE TABLE [dbo].[OrdnanceApprovedForTrainingFacilities](
	[Id] [int] NOT NULL,
	[OrdnanceId] [int] NOT NULL,
	[TrainingFacilitiesId] [int] NOT NULL,
	[AddedByPersonnelId] [int] NOT NULL,
	[AddedTimeDate] [datetime] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_OgraniczeniaSrodkowNaObiektach] PRIMARY KEY CLUSTERED

-------------------------------FK---------------------------------------------
-- OAFTF -> TF
ALTER TABLE [dbo].[OrdnanceApprovedForTrainingFacilities]  WITH CHECK ADD  CONSTRAINT [FK_OgraniczeniaSrodkowNaObiektach_ObiektySzkoleniowe] FOREIGN KEY([TrainingFacilitiesId])
REFERENCES [dbo].[TrainingFacilities] ([Id])

-- OAFTF -> P
ALTER TABLE [dbo].[OrdnanceApprovedForTrainingFacilities]  WITH CHECK ADD  CONSTRAINT [FK_OgraniczeniaSrodkowNaObiektach_Osoby] FOREIGN KEY([AddedByPersonnelId])
REFERENCES [dbo].[Personnel] ([ID])

-- OAFTF -> O
ALTER TABLE [dbo].[OrdnanceApprovedForTrainingFacilities]  WITH CHECK ADD  CONSTRAINT [FK_OgraniczeniaSrodkowNaObiektach_SrodkiBojowe] FOREIGN KEY([OrdnanceId])
REFERENCES [dbo].[Ordnance] ([Id])
-------------------------------FK---------------------------------------------

-----------------------------TWFK---------------------------------------------
-- OT
 CREATE TABLE [dbo].[OrdnanceTransactions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UnitsDepartmentId] [int] NOT NULL,
	[OrdnanceID] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[ClassesID] [int] NULL,
	[OrdnanceAdminId] [int] NOT NULL,
	[TransactionDateTime] [datetime] NOT NULL,
	[Remarks] [nvarchar](150) NULL,
	[OrdnanceTransactionTypeId] [int] NOT NULL,
 CONSTRAINT [PK_OperacjeNaSrodkachBojowych] PRIMARY KEY CLUSTERED

-------------------------------FK---------------------------------------------
-- OT -> UD
ALTER TABLE [dbo].[OrdnanceTransactions]  WITH CHECK ADD  CONSTRAINT [FK_OperacjeNaSrodkachBojowych_KomorkiJW] FOREIGN KEY([UnitsDepartmentId])
REFERENCES [dbo].[UnitsDepartments] ([Id])

-- OT -> OTT
ALTER TABLE [dbo].[OrdnanceTransactions]  WITH CHECK ADD  CONSTRAINT [FK_OperacjeNaSrodkachBojowych_RodzajeOperacjiNaSrodkachBojowych] FOREIGN KEY([OrdnanceTransactionTypeId])
REFERENCES [dbo].[OrdnanceTransactionsTypes] ([Id])

-- OT -> O
ALTER TABLE [dbo].[OrdnanceTransactions]  WITH CHECK ADD  CONSTRAINT [FK_OperacjeNaSrodkachBojowych_SrodkiBojowe] FOREIGN KEY([OrdnanceID])
REFERENCES [dbo].[Ordnance] ([Id])
-------------------------------FK---------------------------------------------

-- OTT
 CREATE TABLE [dbo].[OrdnanceTransactionsTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[Accronym] [nvarchar](5) NOT NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_RodzajeOperacjiNaSrodkachBojowych] PRIMARY KEY CLUSTERED

-----------------------------TWFK---------------------------------------------
-- P
 CREATE TABLE [dbo].[Personnel](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MilitaryRanksId] [int] NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[PESEL] [nchar](11) NOT NULL,
	[Login] [nvarchar](20) NULL,
	[IsDeleted] [bit] NOT NULL,
	[OpNo] [smallint] NULL,
	[PhoneNumber] [nvarchar](12) NULL,
 CONSTRAINT [PK_Osoby] PRIMARY KEY CLUSTERED

-------------------------------FK---------------------------------------------
-- P -> MR
ALTER TABLE [dbo].[Personnel]  WITH CHECK ADD  CONSTRAINT [FK_Osoby_StopnieWojskowe] FOREIGN KEY([MilitaryRanksId])
REFERENCES [dbo].[MilitaryRanks] ([Id]) 
-------------------------------FK---------------------------------------------

-----------------------------TWFK---------------------------------------------
-- PA
 CREATE TABLE [dbo].[PersonnelAuthorisations](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PersonnelId] [int] NOT NULL,
	[AuthorisationsTypesId] [int] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[GroupsForDayRepsId] [int] NULL,
	[TrainingGroupsId] [int] NULL,
 CONSTRAINT [PK_FunkcjeOsob] PRIMARY KEY CLUSTERED

-------------------------------FK---------------------------------------------
-- PA -> P
ALTER TABLE [dbo].[PersonnelAuthorisations]  WITH CHECK ADD  CONSTRAINT [FK_FunkcjeOsob_Osoby] FOREIGN KEY([PersonnelId])
REFERENCES [dbo].[Personnel] ([ID])

-- PA -> TG
ALTER TABLE [dbo].[PersonnelAuthorisations]  WITH CHECK ADD  CONSTRAINT [FK_UprawnieniaOsoby_GrupySzkoleniowe] FOREIGN KEY([TrainingGroupsId])
REFERENCES [dbo].[TrainingGroups] ([Id])

-- PA -> DRGP
ALTER TABLE [dbo].[PersonnelAuthorisations]  WITH CHECK ADD  CONSTRAINT [FK_UprawnieniaOsoby_OsobyWGrupachRaportDzienny] FOREIGN KEY([GroupsForDayRepsId])
REFERENCES [dbo].[DayRepsGroupsPersonnel] ([Id])

-- PA -> AT
ALTER TABLE [dbo].[PersonnelAuthorisations]  WITH CHECK ADD  CONSTRAINT [FK_UprawnieniaOsoby_TypyUprawnien] FOREIGN KEY([AuthorisationsTypesId])
REFERENCES [dbo].[AuthorisationsTypes] ([Id])
-------------------------------FK---------------------------------------------

-----------------------------TWFK---------------------------------------------
-- PAFCF
 CREATE TABLE [dbo].[PersonnelAuthorisedForClassesFunctions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AuthorisationTypesId] [int] NOT NULL,
	[PersonnelId] [int] NOT NULL,
	[StartDate] [date] NOT NULL,
	[EndDate] [date] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_UprawnieniDoFunkcjiNaZajeciach] PRIMARY KEY CLUSTERED

-------------------------------FK---------------------------------------------
-- PAFCF -> FFC
ALTER TABLE [dbo].[PersonnelAuthorisedForClassesFunctions]  WITH CHECK ADD  CONSTRAINT [FK_UprawnieniDoFunkcjiNaZajeciach_FunkcjeNaZajeciach] FOREIGN KEY([AuthorisationTypesId])
REFERENCES [dbo].[FunctionsForClasses] ([Id])-- MSFC -> P

-- PAFCF -> P
ALTER TABLE [dbo].[PersonnelAuthorisedForClassesFunctions]  WITH CHECK ADD  CONSTRAINT [FK_UprawnieniDoFunkcjiNaZajeciach_Osoby] FOREIGN KEY([PersonnelId])
REFERENCES [dbo].[Personnel] ([ID])
-------------------------------FK---------------------------------------------

-----------------------------TWFK---------------------------------------------
-- PIC
 CREATE TABLE [dbo].[PersonnelInClasses](
	[Id] [int] NOT NULL,
	[ClassesId] [int] NOT NULL,
	[PersonnelId] [int] NOT NULL,
	[IsPresent] [bit] NOT NULL,
	[Remarks] [nvarchar](250) NULL,
	[Grade] [tinyint] NULL,
	[InputByLogin] [nvarchar](50) NOT NULL,
	[InputDateTime] [datetime] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[PersonnelInTrainingGroupId] [int] NULL,
 CONSTRAINT [PK_Osoby na zajeciach] PRIMARY KEY CLUSTERED 

-------------------------------FK---------------------------------------------
-- PIC -> C
ALTER TABLE [dbo].[PersonnelInClasses]  WITH CHECK ADD  CONSTRAINT [FK_Osoby na zajeciach_Zajecia1] FOREIGN KEY([PersonnelId])
REFERENCES [dbo].[Classes] ([Id])

-- PIC -> P
ALTER TABLE [dbo].[PersonnelInClasses]  WITH CHECK ADD  CONSTRAINT [FK_OsobyNaZajeciach_Osoby] FOREIGN KEY([PersonnelId])
REFERENCES [dbo].[Personnel] ([ID])
-------------------------------FK---------------------------------------------

-- TA
 CREATE TABLE [dbo].[TrainingAreas](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_PrzedmiotySzkolenia] PRIMARY KEY CLUSTERED

-- TF
 CREATE TABLE [dbo].[TrainingFacilities](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Location] [nvarchar](20) NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_ObiektySzkoleniowe] PRIMARY KEY CLUSTERED 

-- TG
 CREATE TABLE [dbo].[TrainingGroups](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_GrupySzkoleniowe] PRIMARY KEY CLUSTERED 

-----------------------------TWFK---------------------------------------------
-- TGID
 CREATE TABLE [dbo].[TrainingGroupsInDepartments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UnitsDepartmentsId] [int] NOT NULL,
	[TrainingGroups] [int] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_GrupyDlaKomorekJW] PRIMARY KEY CLUSTERED

-------------------------------FK---------------------------------------------
-- TGID -> TG
ALTER TABLE [dbo].[TrainingGroupsInDepartments]  WITH CHECK ADD  CONSTRAINT [FK_GrupyDlaKomorekJW_GrupySzkoleniowe] FOREIGN KEY([TrainingGroups])
REFERENCES [dbo].[TrainingGroups] ([Id])

-- TGID -> UD
ALTER TABLE [dbo].[TrainingGroupsInDepartments]  WITH CHECK ADD  CONSTRAINT [FK_GrupyDlaKomorekJW_KomorkiJW] FOREIGN KEY([UnitsDepartmentsId])
REFERENCES [dbo].[UnitsDepartments] ([Id])
-------------------------------FK---------------------------------------------

-----------------------------TWFK---------------------------------------------
-- TGP
 CREATE TABLE [dbo].[TrainingGroupsPersonnel](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PersonnelId] [int] NOT NULL,
	[TrainingGroupId] [int] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_OsobyWGrupachSzkoleniowych] PRIMARY KEY CLUSTERED

-------------------------------FK---------------------------------------------
-- TGP -> TG
ALTER TABLE [dbo].[TrainingGroupsPersonnel]  WITH CHECK ADD  CONSTRAINT [FK_OsobyWGrupachSzkoleniowych_GrupySzkoleniowe] FOREIGN KEY([TrainingGroupId])
REFERENCES [dbo].[TrainingGroups] ([Id])

-- TGP -> P
ALTER TABLE [dbo].[TrainingGroupsPersonnel]  WITH CHECK ADD  CONSTRAINT [FK_OsobyWGrupachSzkoleniowych_Osoby] FOREIGN KEY([PersonnelId])
REFERENCES [dbo].[Personnel] ([ID])
-------------------------------FK---------------------------------------------

-- UD
 CREATE TABLE [dbo].[UnitsDepartments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_KomorkiJW] PRIMARY KEY CLUSTERED 

-- V
 CREATE TABLE [dbo].[Vehicles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RegistrationPlate] [nchar](15) NOT NULL,
	[Type] [nvarchar](50) NOT NULL,
	[Brand] [nvarchar](50) NOT NULL,
	[Model] [nvarchar](50) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Pojazd] PRIMARY KEY CLUSTERED
