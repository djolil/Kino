﻿namespace Kino.Core.Models.Response
{
    public class MovieCrewHyperTextResponse
    {
        public int PersonId { get; set; }

        public string PersonName { get; set; } = null!;

        public int DepartmentId { get; set; }
    }
}
