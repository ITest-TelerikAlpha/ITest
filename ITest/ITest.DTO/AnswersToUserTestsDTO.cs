﻿using ITest.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITest.DTO
{
    public class AnswersToUserTestsDTO
    {
        public Guid Id { get; set; }

        public Guid UserTestId { get; set; }

        public UserTest UserTest { get; set; }

        public Guid AnswerId { get; set; }

        public Answer Answer { get; set; }
    }
}
