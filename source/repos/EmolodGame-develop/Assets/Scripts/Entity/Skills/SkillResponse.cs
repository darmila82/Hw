using System;
using System.Collections.Generic;

namespace Assets.Scripts.Entity.Skills
{
    public enum ResponseType
    {
        Succsessed = 200,
        Error = 400
    }

    public enum ResultUsingSkill
    {
        Missed = 100,
        Hit = 200,
        CriticalHit = 300
    }

    public class SkillResponse
    {
        private string message = string.Empty;
        private ResponseType responseType;
        private ResultUsingSkill resultUsingSkill;

        public string getMessage() => this.message;
        public ResponseType getResponseType() => this.responseType; 
        public ResultUsingSkill GetResultUsingSkill() => this.resultUsingSkill; 

        public SkillResponse(string message, ResponseType responseType, ResultUsingSkill resultUsingSkill)
        {
            this.message = message;
            this.responseType = responseType;
            this.resultUsingSkill = resultUsingSkill;
        }
    }
}
