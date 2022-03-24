﻿namespace StoryBooks.Libraries.EventBus.Models
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    using Newtonsoft.Json;

    public class Message
    {
        private string serializedData = default!;

        private Message()
        {
        }

        public Message(object data)
            => this.Data = data;

        public int Id { get; private set; }

        public Type Type { get; private set; } = default!;

        public bool Published { get; private set; }

        public void MarkAsPublished() => this.Published = true;

        [NotMapped]
        public object Data
        {
            get => JsonConvert.DeserializeObject(
                this.serializedData, this.Type, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore })
                ?? new { };

            set
            {
                this.Type = value.GetType();

                this.serializedData = JsonConvert.SerializeObject(value,
                    new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            }
        }
    }
}
