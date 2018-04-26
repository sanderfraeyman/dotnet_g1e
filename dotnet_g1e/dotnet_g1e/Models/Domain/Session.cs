
using dotnet_g1e.Models.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

public class Session
{
    public int SessionId { get; private set; }
    public List<SessionPlayGroup> SessionPlayGroups { get; set; }
    public string Name {
        get { return name; }
        set {
            if (value.Trim().Equals("")) throw new ArgumentException("Name can not be empty");
            name = value;
        }
    }
    public string Description { get; set; }
    public DateTime Date {
        get { return date; }
        set {
           // if (DateTime.Compare(value, DateTime.Now) < 0) throw new ArgumentException("Date can not be set in the past");
            date = value;
        }
    }
    public DateTime DateOfCreation
    {
        get { return dateOfCreation; }
        private set { dateOfCreation = DateTime.Now; }
    }
    [NotMapped]
    public List<PlayGroup> Playgroups { get; set; }
    public Classgroup Classgroup { get; set; }
    public Breakoutbox Breakoutbox { get; set; }

    private string name;
    private DateTime dateOfCreation;
    private DateTime date;

	public Session()
	{
	}

    public Session(string name, string description, DateTime date, Classgroup classgroup, Breakoutbox breakoutbox)
    {
        Name = name;
        Description = description;
        Date = date;
        Classgroup = classgroup;
        Breakoutbox = breakoutbox;
        Playgroups = new List<PlayGroup>();
        DateOfCreation = DateTime.Now;
        Breakoutbox.InActiveUse = true;
    }

    public Session(string name, string description, DateTime date, Classgroup classgroup, List<PlayGroup> playgroups, Breakoutbox breakoutbox)
    {
        Name = name;
        Description = description;
        Date = date;
        Classgroup = classgroup;
        Playgroups = playgroups;
        Breakoutbox = breakoutbox;
        DateOfCreation = DateTime.Now;
        Breakoutbox.InActiveUse = true;
    }

    public void AddGroup(PlayGroup playgroup)
    {
        Playgroups.Add(playgroup);
    }

    override
    public string ToString()
    {
        return String.Format("Naam: %s\nBeschrijving: %s\nDatum: %s", Name, Description, Date);
    }
}
