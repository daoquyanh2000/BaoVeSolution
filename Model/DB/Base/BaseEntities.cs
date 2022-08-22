using System;
using System.ComponentModel.DataAnnotations;

namespace BaoVeSolution.WebApplication.DB.Base
{
    public class BaseEntities
    {
        public State State { get; set; }
    }
    public enum State
    {
        Inactive,
        Active
    }

}
