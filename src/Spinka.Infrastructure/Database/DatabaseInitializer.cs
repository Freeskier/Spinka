using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Fare;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using RandomNameGeneratorLibrary;
using Spinka.Domain.Models;
using Spinka.Domain.Models.Enums;

namespace Spinka.Infrastructure.Database
{
    public static class DatabaseInitializer
    {
        public static async Task PrepPopulation(IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            await SeedData(serviceScope.ServiceProvider.GetService<SpinkaContext>());
        }

        private static async Task SeedData(SpinkaContext context)
        {
            Console.WriteLine("Appling Migrations...");
            
            await context.Database.MigrateAsync();
            
            if (!context.AuthorizationsTypes.Any())
            {
                Console.WriteLine("Adding data to authorization type - seeding...");
                await context.AddRangeAsync(AddAuthorizationTypes());
                await context.SaveChangesAsync();
            }
            if (!context.UnitDepartments.Any())
            {
                Console.WriteLine("Adding data to unit department - seeding...");
                await context.AddRangeAsync(AddUnitDepartments());
                await context.SaveChangesAsync();
            }
            if (!context.AmmoTypes.Any())
            {
                Console.WriteLine("Adding data to group of ordance - seeding...");
                await context.AddRangeAsync(AddAmmoTypes());
                await context.SaveChangesAsync();
            }
            
            if (!context.MeasureUnits.Any())
            {
                Console.WriteLine("Adding data to measure unit - seeding...");
                await context.AddRangeAsync(AddMeasureUnits());
                await context.SaveChangesAsync();
            }
            
            if (!context.Ammo.Any())
            {
                Console.WriteLine("Adding data to ordance - seeding...");
                await context.AddRangeAsync(AddAmmo());
                await context.SaveChangesAsync();
            }
            
            if (!context.AmmoTransactionTypes.Any())
            {
                Console.WriteLine("Adding data to ordance transaction type - seeding...");
                await context.AddRangeAsync(AddAmmoTransactionTypes());
                await context.SaveChangesAsync();
            }
                
            if (!context.Persons.Any())
            {
                Console.WriteLine("Adding data to person - seeding...");
                await context.AddRangeAsync(AddPersons());
                await context.SaveChangesAsync();
            }
            
            if (!context.PersonAuthorisedForEduBlockFunctions.Any())
            {
                Console.WriteLine("Adding data to person authorization for edu block - seeding...");
                await context.AddRangeAsync(AddPersonAuthorisedForEduBlockFunctions());
                await context.SaveChangesAsync();
            }
            
            if (!context.TrainingAreas.Any())
            {
                Console.WriteLine("Adding data to training area - seeding...");
                await context.AddRangeAsync(AddTrainingAreas());
                await context.SaveChangesAsync();
            }
            
            if (!context.TrainingFacilities.Any())
            {
                Console.WriteLine("Adding data to training facility - seeding...");
                await context.AddRangeAsync(AddTrainingFacilities());
                await context.SaveChangesAsync();
            }
            
            if (!context.TrainingGroups.Any())
            {
                Console.WriteLine("Adding data to training group - seeding...");
                await context.AddRangeAsync(AddTrainingGroups());
                await context.SaveChangesAsync();
            }
            
            if (!context.TrainingGroupsPersons.Any())
            {
                Console.WriteLine("Adding data to person in training group - seeding...");
                await context.AddRangeAsync(AddTrainingGroupPersons());
                await context.SaveChangesAsync();
            }
            
            
            
            if (!context.TrainingGroupsInDepartments.Any())
            {
                Console.WriteLine("Adding data to training group in department - seeding...");
                await context.AddRangeAsync(AddTrainingGroupsInDepartments());
                await context.SaveChangesAsync();
            }
            
            if (!context.GroupForDayReps.Any())
            {
                Console.WriteLine("Adding data to training group in day reps - seeding...");
                await context.AddRangeAsync(AddGroupForDayReps());
                await context.SaveChangesAsync();
            }
            
            if (!context.EduBlockSubjects.Any())
            {
                Console.WriteLine("Adding data to subject class - seeding...");
                await context.AddRangeAsync(AddEduBlockSubjects());
                await context.SaveChangesAsync();
            }

            if (!context.Vehicles.Any())
            {
                Console.WriteLine("Adding data to vehicle - seeding...");
                await context.AddRangeAsync(AddVehicles());
                await context.SaveChangesAsync();
            }

            if (!context.CurrentAmmoLimitsForDepartments.Any())
            {
                Console.WriteLine("Adding data to current ordnance limits for department - seeding...");
                await context.AddRangeAsync(AddCurrentAmmoLimitsForDepartments());
                await context.SaveChangesAsync();
            }

            if (!context.AvailabilityRoles.Any())
            {
                Console.WriteLine("Adding data to availability role - seeding...");
                await context.AddRangeAsync(AddAvailabilityRoles());
                await context.SaveChangesAsync();
            }
            
            if (!context.AvailabilityTypes.Any())
            {
                Console.WriteLine("Adding data to availability type - seeding...");
                await context.AddRangeAsync(AddAvailabilityTypes());
                await context.SaveChangesAsync();
            }
            
            if (!context.AmmoTransactions.Any())
            {
                Console.WriteLine("Adding data to ordnance transaction - seeding...");
                await context.AddRangeAsync(AddAmmoTransactions());
                await context.SaveChangesAsync();
            }

            if (!context.EventTypes.Any())
            {
                Console.WriteLine("Adding data to event type - seeding...");
                await context.AddRangeAsync(AddEventTypes());
                await context.SaveChangesAsync();
            }
            
            Console.WriteLine("Already have data - not seeding");
        }
        
        #region MockDb
        
        private static IEnumerable<AuthorizationsType> AddAuthorizationTypes()
        {
            return new List<AuthorizationsType>
            {
                new AuthorizationsType
                {
                    Name = "Administrator"
                },
                new AuthorizationsType
                {
                    Name = "Administrator_Szkolenia"
                },
                new AuthorizationsType
                {
                    Name = "Edycja_Strojówki"
                },
                new AuthorizationsType
                {
                    Name = "Edycja_Szkolenia"
                },
                new AuthorizationsType
                {
                    Name = "Edycja_Zabezpieczenia_Medycznego"
                },
                new AuthorizationsType
                {
                    Name = "Edycja_Obiektów_Szkoleniowych"
                },
                new AuthorizationsType
                {
                    Name = "Edycja_Strojówki"
                },
                new AuthorizationsType
                {
                    Name = "Przegląd_Szkolenia"
                },
                new AuthorizationsType
                {
                    Name = "Super_Użytkownik"
                },
                new AuthorizationsType
                {
                    Name = "Lekarz"
                },
                new AuthorizationsType
                {
                    Name = "Paramedyk"
                },
                new AuthorizationsType
                {
                    Name = "Materiały_Wybuchowe"
                },
                new AuthorizationsType
                {
                    Name = "Kierownik_Strzelania"
                }
            };
        }
        
        private static IEnumerable<PersonAuthorisedForEduBlockFunction> AddPersonAuthorisedForEduBlockFunctions()
        {
            return new List<PersonAuthorisedForEduBlockFunction>
            {
                new PersonAuthorisedForEduBlockFunction
                {
                    AuthorisationsTypeId = 10,
                    PersonId = 1,
                    StartDate = DateTime.Now,
                    EndOn = DateTime.Now
                },
                new PersonAuthorisedForEduBlockFunction
                {
                    AuthorisationsTypeId = 10,
                    PersonId = 2,
                    StartDate = DateTime.Now,
                    EndOn = DateTime.Now
                },
                new PersonAuthorisedForEduBlockFunction
                {
                    AuthorisationsTypeId = 11,
                    PersonId = 3,
                    StartDate = DateTime.Now,
                    EndOn = DateTime.Now
                },
                new PersonAuthorisedForEduBlockFunction
                {
                    AuthorisationsTypeId = 11,
                    PersonId = 4,
                    StartDate = DateTime.Now,
                    EndOn = DateTime.Now
                }
            };
        }    
        
        private static IEnumerable<AmmoType> AddAmmoTypes()
        {
            return new List<AmmoType>
            {
                new AmmoType
                {
                    Name = "Materiał wybuchowy"
                },
                new AmmoType
                {
                    Name = "Amunicja"
                },
                new AmmoType
                {
                    Name = "Ciężki sprzęt"
                },
                new AmmoType
                {
                    Name = "Szkoleniowe"
                }
            };
        }
        
        private static IEnumerable<MeasureUnit> AddMeasureUnits()
        {
            return new List<MeasureUnit>
            {
                new MeasureUnit
                {
                    Name = "Metr",
                    Acronym = "m"
                },
                new MeasureUnit
                {
                    Name = "Kilogram",
                    Acronym = "kg"
                },
                new MeasureUnit
                {
                    Name = "Sztuka",
                    Acronym = "szt"
                }
            };
        }
        
        private static IEnumerable<Ammo> AddAmmo()
        {
            return new List<Ammo>
            {
                new Ammo
                {
                    Name = "5,56mm nb zap",
                    LogIndex = "abcd1234",
                    IsDangerous = false,
                    MeasureUnitId = 1,
                    AmmoTypeId = 2
                },
                new Ammo
                {
                    Name = "5,56mm nb ",
                    LogIndex = "abcd1234",
                    IsDangerous = false,
                    MeasureUnitId = 1,
                    AmmoTypeId = 2
                },
                 new Ammo
                {
                    Name = "9mm nb ",
                    LogIndex = "abcd1234",
                    IsDangerous = false,
                    MeasureUnitId = 1,
                    AmmoTypeId = 2
                },
                   new Ammo
                {
                    Name = "9mm nb spec.",
                    LogIndex = "abcd1234",
                    IsDangerous = false,
                    MeasureUnitId = 1,
                    AmmoTypeId = 2
                },
              
                new Ammo
                {
                    Name = "Blade",
                    LogIndex = "1234rewq",
                    IsDangerous = true,
                    MeasureUnitId = 2,
                    AmmoTypeId = 1
                },
                new Ammo
                {
                    Name = "STS",
                    LogIndex = "1234rewq",
                    IsDangerous = true,
                    MeasureUnitId = 2,
                    AmmoTypeId = 1
                }
            };
        }
        
        private static IEnumerable<AmmoTransactionType> AddAmmoTransactionTypes()
        {
            return new List<AmmoTransactionType>
            {
                new AmmoTransactionType
                {
                    Name = "Przesunięcie",
                    Acronym = "P"
                },
                new AmmoTransactionType
                {
                    Name = "Wybrakowanie",
                    Acronym = "W"
                },
                new AmmoTransactionType
                {
                    Name = "Zwrot z zajęć",
                    Acronym = "Zz"
                },
                new AmmoTransactionType
                {
                    Name = "Zajęcia",
                    Acronym = "Z"
                },
                new AmmoTransactionType
                {
                    Name = "Zwiększenie limitu",
                    Acronym = "Zw"
                },
                new AmmoTransactionType
                {
                    Name = "Zmniejszenie limitu",
                    Acronym = "Zm"
                }
            };
        }
        
        private static IEnumerable<TrainingArea> AddTrainingAreas()
        {
            return new List<TrainingArea>
            {
                new TrainingArea
                {
                    Name = "Taktyka",
                    TrainingAcronym = "T"
                },
                new TrainingArea
                {
                    Name = "WF",
                    TrainingAcronym = "WF"
                },
                new TrainingArea
                {
                    Name = "Szkolenie ogniowe",
                    TrainingAcronym = "SzO"
                },
                new TrainingArea
                {
                    Name = "Szkolenie Wysokościowe",
                    TrainingAcronym = "SzWys"
                },
                new TrainingArea
                {
                    Name = "Szkolenie medyczne",
                    TrainingAcronym = "SzMed"
                },
                new TrainingArea
                {
                    Name = "Łączność",
                    TrainingAcronym = "Ł"
                }
            };
        }
        
        private static IEnumerable<TrainingFacility> AddTrainingFacilities()
        {
            return new List<TrainingFacility>
            {
                new TrainingFacility
                {
                    Name = "Ośrodek EOD",
                    Location = "Warszawa"
                },
                new TrainingFacility
                {
                    Name = "Strzelnica nr 1",
                    Location = "Warszawa"
                },new TrainingFacility
                {
                    Name = "Strzelnica nr 2",
                    Location = "Warszawa"
                },new TrainingFacility
                {
                    Name = "Strzelnica nr 3",
                    Location = "Warszawa"
                },
                new TrainingFacility
                {
                    Name = "Hala Sportowa",
                    Location = "Warszawa"
                }
            };
        }
        
        private static IEnumerable<TrainingGroup> AddTrainingGroups()
        {
            return new List<TrainingGroup>
            {
                new TrainingGroup
                {
                    Name = " Z1 GW"
                },
                new TrainingGroup
                {
                    Name = " Z1 GD"
                },
                new TrainingGroup
                {
                    Name = " Z1 G1"
                },
                new TrainingGroup
                {
                    Name = " Z1 G2"
                },
                  new TrainingGroup
                {
                    Name = " Z2 GW"
                },
                new TrainingGroup
                {
                    Name = " Z2 GD"
                },
                new TrainingGroup
                {
                    Name = " Z2 G1"
                },
                new TrainingGroup
                {
                    Name = " Z2 G2"
                },
                new TrainingGroup
                {
                    Name = "Materiałówka"
                },
                new TrainingGroup
                {
                    Name = "Uzbrojenie"
                },
                new TrainingGroup
                {
                    Name = "Środki Bojowe"
                }
            };
        }
        
        private static IEnumerable<UnitDepartment> AddUnitDepartments()
        {
            return new List<UnitDepartment>
            {
                new UnitDepartment
                {
                    Name ="Zespół 1"
                },
                new UnitDepartment
                {
                    Name = "Zespół 2"
                },
                new UnitDepartment
                {
                    Name =  "Logistyka"
                }
            };
        }
        
        private static IEnumerable<TrainingGroupsInDepartment> AddTrainingGroupsInDepartments()
        {
            return new List<TrainingGroupsInDepartment>
            {
                new TrainingGroupsInDepartment
                {
                    TrainingGroupId = 1,
                    UnitDepartmentsId = 1
                },
                new TrainingGroupsInDepartment
                {
                    TrainingGroupId = 2,
                    UnitDepartmentsId = 1
                },
                new TrainingGroupsInDepartment
                {
                    TrainingGroupId = 3,
                    UnitDepartmentsId = 1
                },
                new TrainingGroupsInDepartment
                {
                    TrainingGroupId = 4,
                    UnitDepartmentsId = 2
                },
                new TrainingGroupsInDepartment
                {
                    TrainingGroupId = 5,
                    UnitDepartmentsId = 2
                },
                new TrainingGroupsInDepartment
                {
                    TrainingGroupId = 6,
                    UnitDepartmentsId = 2
                },
                new TrainingGroupsInDepartment
                {
                    TrainingGroupId = 7,
                    UnitDepartmentsId = 2
                },
                new TrainingGroupsInDepartment
                {
                    TrainingGroupId = 8,
                    UnitDepartmentsId = 3
                },
                new TrainingGroupsInDepartment
                {
                    TrainingGroupId = 9,
                    UnitDepartmentsId = 3
                }                ,
                new TrainingGroupsInDepartment
                {
                    TrainingGroupId = 10,
                    UnitDepartmentsId = 3
                },
                new TrainingGroupsInDepartment
                {
                    TrainingGroupId = 11,
                    UnitDepartmentsId = 3
                }

            };
        }
        
        private static IEnumerable<EduBlockSubject> AddEduBlockSubjects()
        {
            return new List<EduBlockSubject>
            {
                new EduBlockSubject
                {
                    Subject = "Marsz ubezpieczony",
                    TrainingAreaId = 6
                },new EduBlockSubject
                {
                    Subject = "Zdobywanie budynku",
                    TrainingAreaId = 6
                },new EduBlockSubject
                {
                    Subject = "Planowanie operacji",
                    TrainingAreaId = 6
                },new EduBlockSubject
                {
                    Subject = "Działanie w terenie zurbanizowanym",
                    TrainingAreaId = 6
                },
                new EduBlockSubject
                {
                    Subject = "Strzelanie dynamiczne",
                    TrainingAreaId = 4
                },new EduBlockSubject
                {
                    Subject = "Strzelanie na krótkich dystansach",
                    TrainingAreaId = 4
                },new EduBlockSubject
                {
                    Subject = "Strzelanie w pomieszczeniach",
                    TrainingAreaId = 4
                },new EduBlockSubject
                {
                    Subject = "Budowa broni",
                    TrainingAreaId = 4
                },
                new EduBlockSubject
                {
                    Subject = "Wodzenie piłki wzrokiem",
                    TrainingAreaId = 5,
                },
                new EduBlockSubject
                {
                    Subject = "Pompki z pamięci",
                    TrainingAreaId = 5,
                },
                new EduBlockSubject
                {
                    Subject = "Turlanie sztangi piętą",
                    TrainingAreaId = 5,
                },
                new EduBlockSubject
                {
                    Subject = "Sprzęt wysokościowy",
                    TrainingAreaId = 3,
                },
                new EduBlockSubject
                {
                    Subject = "Zakładanie stanowiska",
                    TrainingAreaId = 3,
                },
                new EduBlockSubject
                {
                    Subject = "TCCC",
                    TrainingAreaId = 2,
                },
                new EduBlockSubject
                {
                    Subject = "Triaż i ewakuacja rannych",
                    TrainingAreaId = 2,
                },
                new EduBlockSubject
                {
                    Subject = "Rozwijanie systemów łączności",
                    TrainingAreaId = 1,
                }
            };
        }

        private static IEnumerable<Vehicle> AddVehicles()
        {
            return new List<Vehicle>
            {
                new Vehicle
                {
                    RegisterNumber = "WWE0987",
                    VehicleType = VehicleType.Ambulance,
                    Brand = "Mercedes",
                    Model = "Sprinter"
                },
                new Vehicle
                {
                    RegisterNumber = "UA27890",
                    VehicleType = VehicleType.Star,
                    Brand = "Star",
                    Model = "Star"
                },
                new Vehicle
                {
                    RegisterNumber = "WWE0986",
                    VehicleType = VehicleType.MarksmanCar,
                    Brand = "VW",
                    Model = "Transporter"
                }
            };
        }
        
        private static IEnumerable<AvailabilityRole> AddAvailabilityRoles()
        {
            return new List<AvailabilityRole>
            {
                new AvailabilityRole
                {
                    Role = "Dowódca grupy"
                },
                new AvailabilityRole
                {
                    Role = "Kierowca 1"
                },
                new AvailabilityRole
                {
                    Role = "Kierowca 2"
                }
            };
        }
        
        private static IEnumerable<AvailabilityType> AddAvailabilityTypes()
        {
            return new List<AvailabilityType>
            {
                new AvailabilityType
                {
                    Type = "Brak"
                },
                new AvailabilityType
                {
                    Type = "3 godziny"
                },
                new AvailabilityType
                {
                    Type = "6 godzin"
                },
                new AvailabilityType
                {
                    Type = "12 godzin"
                }
            };
        }
        
        private static IEnumerable<CurrentAmmoLimitsForDepartment> AddCurrentAmmoLimitsForDepartments()
        {
            return new List<CurrentAmmoLimitsForDepartment>
            {
                new CurrentAmmoLimitsForDepartment
                {
                    Quantity = 150000,
                    ActualizationDate = DateTime.Now,
                    UnitDepartmentsId = 3,
                    AmmoId = 2
                }, new CurrentAmmoLimitsForDepartment
                {
                    Quantity = 50000,
                    ActualizationDate = DateTime.Now,
                    UnitDepartmentsId = 3,
                    AmmoId = 1
                }, new CurrentAmmoLimitsForDepartment
                {
                    Quantity = 500000,
                    ActualizationDate = DateTime.Now,
                    UnitDepartmentsId = 3,
                    AmmoId = 3
                }, new CurrentAmmoLimitsForDepartment
                {
                    Quantity = 20000,
                    ActualizationDate = DateTime.Now,
                    UnitDepartmentsId = 3,
                    AmmoId = 4
                }, new CurrentAmmoLimitsForDepartment
                {
                    Quantity = 200,
                    ActualizationDate = DateTime.Now,
                    UnitDepartmentsId = 3,
                    AmmoId = 5
                }, new CurrentAmmoLimitsForDepartment
                {
                    Quantity = 160000,
                    ActualizationDate = DateTime.Now,
                    UnitDepartmentsId = 2,
                    AmmoId = 2
                }, new CurrentAmmoLimitsForDepartment
                {
                    Quantity = 70000,
                    ActualizationDate = DateTime.Now,
                    UnitDepartmentsId = 2,
                    AmmoId = 1
                }, new CurrentAmmoLimitsForDepartment
                {
                    Quantity = 900000,
                    ActualizationDate = DateTime.Now,
                    UnitDepartmentsId = 2,
                    AmmoId = 3
                }, new CurrentAmmoLimitsForDepartment
                {
                    Quantity = 40000,
                    ActualizationDate = DateTime.Now,
                    UnitDepartmentsId = 2,
                    AmmoId = 4
                }, new CurrentAmmoLimitsForDepartment
                {
                    Quantity = 100,
                    ActualizationDate = DateTime.Now,
                    UnitDepartmentsId = 2,
                    AmmoId = 5
                },

                new CurrentAmmoLimitsForDepartment
                {
                    Quantity = 56000,
                    ActualizationDate = DateTime.Now.AddDays(-2),
                    UnitDepartmentsId = 1,
                    AmmoId = 2
                },
                new CurrentAmmoLimitsForDepartment
                {
                    Quantity = 10000,
                    ActualizationDate = DateTime.Now.AddDays(-4),
                    UnitDepartmentsId = 1,
                    AmmoId = 3
                }
            };
        }
        
        private static IEnumerable<AmmoTransaction> AddAmmoTransactions()
        {
            return new List<AmmoTransaction>
            {
                new AmmoTransaction
                {
                    Quantity = 1000,
                    AmmoAdminId = 2,
                    TransactionDateTime = DateTime.Now,
                    Remarks = "Brak uwag",
                    AmmoTransactionTypeId = 2,
                    CurrentAmmoLimitsForDepartmentId = 2
                },
                new AmmoTransaction
                {
                    Quantity = 100,
                    AmmoAdminId = 1,
                    TransactionDateTime = DateTime.Now,
                    Remarks = "Brak uwag",
                    AmmoTransactionTypeId = 1,
                    CurrentAmmoLimitsForDepartmentId = 1
                },
                new AmmoTransaction
                {
                    Quantity = 1000,
                    AmmoAdminId = 3,
                    TransactionDateTime = DateTime.Now,
                    Remarks = "Brak uwag",
                    AmmoTransactionTypeId = 3,
                    CurrentAmmoLimitsForDepartmentId = 3
                }
            };
        } 
        
        private static IEnumerable<Person> AddPersons()
        {
            const string personalIdRegex = "^[0-9]{11}$";
            const string phoneNumberRegex = "^[0-9]{9}$";

            var personalId = new Xeger(personalIdRegex, new Random());
            var phoneNumber = new Xeger(phoneNumberRegex, new Random());
            var randomMilitaryRank = new Random();

            var personGenerator = new PersonNameGenerator();
            var persons = new List<Person>();

            for (var i = 0; i < 600; i++)
            {
                var militaryRank = randomMilitaryRank.Next(18);
                persons.Add(new Person
                {
                    FirstName = personGenerator.GenerateRandomFirstName(),
                    LastName = personGenerator.GenerateRandomLastName(),
                    Pesel = personalId.Generate(),
                    Login = $"login{i}",
                    OpNo = i,
                    PhoneNumber = phoneNumber.Generate(),
                    MilitaryRankId = militaryRank == 0 ? (int?) null : militaryRank,
                    Father = "s. Janusza"
                });
            }
            return persons;
        }
        
        private static IEnumerable<TrainingGroupsPerson> AddTrainingGroupPersons()
        {
            var trainingGroupPersons = new List<TrainingGroupsPerson>();
            var randomGroup = new Random();

            for (var i = 1; i <= 600; i++)
            {
                var group = randomGroup.Next(1,11);
                trainingGroupPersons.Add(new TrainingGroupsPerson
                {
                    PersonId = i,
                    TrainingGroupId = group
                });
            }
            return trainingGroupPersons;
        }

        private static IEnumerable<GroupForDayRep> AddGroupForDayReps()
        {
            return new List<GroupForDayRep>
            {
                new GroupForDayRep
                {
                    Name = "Z1",
                    UnitDepartmentsId = 3
                },
                new GroupForDayRep
                {
                    Name = "Z2",
                    UnitDepartmentsId = 2
                },
                new GroupForDayRep
                {
                    Name = "LogMat",
                    UnitDepartmentsId = 3
                },
                new GroupForDayRep
                {
                    Name = "LogUzbr",
                    UnitDepartmentsId = 3
                },
             
            };
        }
        
        
        private static IEnumerable<EventType> AddEventTypes()
        {
            return new List<EventType>
            {
                new EventType
                {
                    Name = "Ćwiczenie krajowe",
                    Acr = "ĆwKraj",
                    Color = "#8f7765"
                },
                new EventType
                {
                    Name = "Ćwiczenie zagraniczne",
                    Acr = "ĆwZag",
                    Color = "#6b513e"
                },
                new EventType
                {
                    Name = "Ćwiczenie sztabowe",
                    Acr = "ĆwSztab",
                    Color = "#452d1c"
                },
                new EventType
                {
                    Name = "Poligon",
                    Acr = "Pol",
                    Color = "#6b7a0a"
                },
                new EventType
                {
                    Name = "Szkolenie spadochronowe",
                    Acr = "SzkSpad",
                    Color = "#4287f5"
                },
                new EventType
                {
                    Name = "Szkolenie specjalistyczne",
                    Acr = "SzkSpec",
                    Color = "#2a5ba8"
                },
                new EventType
                {
                    Name = "Szkolenie zagraniczne",
                    Acr = "SzkZag",
                    Color = "#123873"
                },
                new EventType
                {
                    Name = "Konferencja",
                    Acr = "Konf",
                    Color = "#65a1a6"
                },
                new EventType
                {
                    Name = "Konferencja zagraniczna",
                    Acr = "KonfZag",
                    Color = "#226166"
                },
                new EventType
                {
                    Name = "Wizyta w Jednostce",
                    Acr = "Wiz",
                    Color = ""
                },
                new EventType
                {
                    Name = "Certyfikacja",
                    Acr = "Cert",
                    Color = "#2c2f6e"
                },
                new EventType
                {
                    Name = "Refit",
                    Acr = "Ref",
                    Color = "#303013"
                },
                new EventType
                {
                    Name = "Misja",
                    Acr = "Mis",
                    Color = " #593d29"
                }
            };
        }

        #endregion
    }
}