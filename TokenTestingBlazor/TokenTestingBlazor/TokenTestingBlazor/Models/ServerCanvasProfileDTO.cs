﻿namespace TokenTestingBlazor.Models
{
    /// <summary>
    /// Data transfer object for a Canvas profile.
    /// </summary>
    public class ServerCanvasProfileDTO
    {
        public int id { get; set; }
        public string login_id { get; set; }
        public string avatar_url { get; set; }
        public string effective_locale { get; set; }
        public string name { get; set; }
    }
}
