﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VotingModelLibrary.Models
{
    public class Candidate
    {
        [Key]
        [Display(Name = "CandidateId")]
        public int CandidateId { get; set; }

        [Display(Name = "ElectionId")]
        public int ElectionId { get; set; }
        public Election Election { get; set; }

        [Display (Name="FirstName")]
        public string FirstName { get; set; }
        [Display(Name = "LastName")]
        public string LastName { get; set; }
        [Display(Name = "Picture")]
        public string Picture { get; set; }
        [Display(Name = "Biography")]
        public string Biography { get; set; }
        [Display(Name = "OrganizationId")]
        public int OrganizationId { get; set; }

        
        [Display(Name = "Organization")]
        public Organization Organization { get; set; }

        [Display(Name = "CandidateRaces")]
        public List<CandidateRace> CandidateRaces { get; set; }
        [Display(Name = "Contacts")]
        public List<Contact> Contacts { get; set; }
    }
}
