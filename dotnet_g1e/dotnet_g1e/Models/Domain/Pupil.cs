using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace dotnet_g1e.Models.Domain
{
    public class Pupil
    {
        public int PupilId { get; private set; }
        public List<ClassGroupPupil> ClassGroupPupils { get; set; }
        public List<PlayGroupPupil> PlayGroupPupils { get; set; }
        public string FirstName
        {
            get { return firstName; }
            private set
            {
                var regex = new Regex("[a-zA-ZàáâäãåąčćęèéêëėįìíîïłńòóôöõøùúûüųūÿýżźñçčšžÀÁÂÄÃÅĄĆČĖĘÈÉÊËÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑßÇŒÆČŠŽ∂ð .'-]+");
                if (value.Trim().Equals(""))
                    throw new ArgumentException("the name of a pupil can not be empty");
                if (!regex.IsMatch(value))
                    throw new ArgumentException("the name of a pupil has to contain only accepted characters (alphabetic, spaces, -, ', .)");
                firstName = value;
            }
        }
        public string LastName
        {
            get { return lastName; }
            private set
            {
                var regex = new Regex("[a-zA-ZàáâäãåąčćęèéêëėįìíîïłńòóôöõøùúûüųūÿýżźñçčšžÀÁÂÄÃÅĄĆČĖĘÈÉÊËÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑßÇŒÆČŠŽ∂ð .'-]+");
                if (value.Trim().Equals(""))
                    throw new ArgumentException("the name of a pupil can not be empty");
                if (!regex.IsMatch(value))
                    throw new ArgumentException("the name of a pupil has to contain only accepted characters (alphabetic, spaces, -, ', .)");
                lastName = value;
            }
        }

        private string firstName;
        private string lastName;

        public Pupil(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public Pupil() { }

        override
        public string ToString()
        {
            return String.Format("%s %s", FirstName, LastName);
        }
    } 
}
