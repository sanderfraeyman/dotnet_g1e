using dotnet_g1e.Models;
using dotnet_g1e.Models.Domain;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g1e.Data
{
    public class BreakoutboxDataInitializer
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<ApplicationUser> _userManager;

        public BreakoutboxDataInitializer(ApplicationDbContext dbContext, UserManager<ApplicationUser> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        private async Task InitializeUsers()
        {
            string email = "admin@breakoutbox.com";
            ApplicationUser user = new ApplicationUser { UserName = email, Email = email };
            await _userManager.CreateAsync(user, "P@sswo0rd");

            string email2 = "tyler@breakoutbox.com";
            ApplicationUser user2 = new ApplicationUser { UserName = email2, Email = email2 };
            await _userManager.CreateAsync(user2, "Tyler123");

            string email3 = "gregor@breakoutbox.com";
            ApplicationUser user3 = new ApplicationUser { UserName = email3, Email = email3 };
            await _userManager.CreateAsync(user3, "Gregor123");

            string email4 = "sander@breakoutbox.com";
            ApplicationUser user4 = new ApplicationUser { UserName = email4, Email = email4 };
            await _userManager.CreateAsync(user4, "Sander123");

            string email5 = "benjamin@breakoutbox.com";
            ApplicationUser user5 = new ApplicationUser { UserName = email5, Email = email5 };
            await _userManager.CreateAsync(user5, "Benjamin123");
        }

        public async Task InitializeData()
        {
            _dbContext.Database.EnsureDeleted();
            if (_dbContext.Database.EnsureCreated())
            {
                await InitializeUsers();

                //initialize other data
                //MODIFIERS
                List<Modifier> modifiers = new List<Modifier>();
                for (int i = 0; i <= 10; i++)
                {
                    modifiers.Add(new AddModifier("+" + i + 1));
                }

                //EXERCISES
                List<Exercise> exercises = new List<Exercise>();
                for (int i = 0; i <= 1; i++)
                {
                    Result<string> result = new Result<string>(String.Format("%d", i * 5));
                    Exercise mathExercise = new Exercise(String.Format("Optellingen_oefening%d", i), result, modifiers);
                    mathExercise.Course = "Wiskunde";
                    mathExercise.TimeLimit = i+5;
                    exercises.Add(mathExercise);
                }
                for (int i = 0; i <= 1; i++)
                {
                    Result<string> result = new Result<string>(String.Format("Aantal dt gevallen = %d", i * 2));
                    Exercise dutchExercise = new Exercise(String.Format("Werkwoorden_dt-fout_oefening%d", i), result, modifiers);
                    dutchExercise.Course = "Nederlands";
                    dutchExercise.TimeLimit = i + 5;
                    exercises.Add(dutchExercise);
                }
                    
                for(int i = 0; i <= 2; i++)
                {
                    Result<string> result = new Result<string>(String.Format("vocablist%d", i));
                    Exercise englishExercise = new Exercise(String.Format("Vocalbulary_Greeting_Exercise%d", i), result, modifiers);
                    englishExercise.Course = "Engels";
                    englishExercise.TimeLimit = i+5;
                    exercises.Add(englishExercise);

                }
                    
                for(int i = 0; i <= 2; i++)
                {
                    Result<string> result = new Result<string>(String.Format("vocabulaire%d", i));
                    Exercise frenchExercise = new Exercise(String.Format("ConjuguerVerbes_exercices%d", i), result, modifiers);
                    frenchExercise.Course = "Frans";
                    frenchExercise.TimeLimit = i+5;
                    exercises.Add(frenchExercise);

                }

                //PUPILS
                List<Pupil> pupils = new List<Pupil>();
                Pupil gregor = new Pupil("Grégor", "Christiaens");
                Pupil sander = new Pupil("Sander", "Fraeyman");
                Pupil tyler = new Pupil("Tyler", "Steyaert");
                Pupil benjamin = new Pupil("Benjamin", "van Iseghem");
                pupils.AddRange(new List<Pupil> { gregor, sander, tyler, benjamin });

                //CLASSGROUPS
                List<Classgroup> classGroups = new List<Classgroup>();
                classGroups.Add(new Classgroup("grender", pupils.GetRange(0, 1)));
                classGroups.Add(new Classgroup("tyljamin", pupils.GetRange(1,2)));
                classGroups.Add(new Classgroup("PWII_E1", pupils.GetRange(0, 2)));

                //PLAYGROUPS
                List<PlayGroup> groups = new List<PlayGroup>();
                groups.Add(new PlayGroup("gc_1", pupils.GetRange(0, 1)));
                groups.Add(new PlayGroup("sf_1", pupils.GetRange(0, 1)));
                groups.Add(new PlayGroup("ts_1", pupils.GetRange(0, 2)));
                groups.Add(new PlayGroup("bvi_1", pupils.GetRange(0, 2)));

                //ACTIONS
                List<Models.Domain.Action> actions = new List<Models.Domain.Action>();
                for(int i = 0; i <= 10; i++)
                {
                    actions.Add(new Models.Domain.Action("Naam" + i, "Voer deze uit om je unieke code te verkrijgen"));
                }

                //ACCESSCODES
                List<AccessCode> accessCodes = new List<AccessCode>();
                for(int i = 0; i <= 10; i++)
                {
                    accessCodes.Add(new AccessCode((i + 3) * 55 + ""));
                }

                //BREAKOUTBOXES
                List<Breakoutbox> breakoutboxes = new List<Breakoutbox>();
                for(int i = 0; i <= 3; i++)
                {
                    breakoutboxes.Add(new Breakoutbox("FirstSession" + i, "Dit is een eerste oefenbox", actions, accessCodes, exercises));
                }

                //SESSIONS
                List<Session> sessions = new List<Session>();
                for(int i = 0; i <= 3; i++)
                {
                    sessions.Add(new Session("FirstSession" + i, "Dit is een eerste sessie", new DateTime(), i==3?classGroups[i-1]:classGroups[i], groups, breakoutboxes[i]));
                }

                _dbContext.Sessions.AddRange(sessions);
                _dbContext.Breakoutboxes.AddRange(breakoutboxes);
                _dbContext.Exercises.AddRange(exercises);
                _dbContext.SaveChanges();
            }
        }
    }
}
