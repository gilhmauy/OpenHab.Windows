﻿using System.Collections.Generic;
using Newtonsoft.Json;

namespace OpenHab.Client
{
    public class Widget
    {
        public string WidgetId { get; set; }

        public WidgetType Type { get; set; }

        public string Label { get; set; }

        public string Icon { get; set; }

        public string Url { get; set; }

        public double MinValue { get; set; }

        public double MaxValue { get; set; }

        public double Step { get; set; }

        public int Refresh { get; set; }

        public string Period { get; set; }

        public string Service { get; set; }

        public int Height { get; set; }

        public string LabelColor { get; set; }

        public string ValueColor { get; set; }

        public string Encoding { get; set; }

        [JsonProperty("widget")]
        [JsonConverter(typeof(SingleOrArrayConverter<Widget>))]
        public IList<Widget> Widgets { get; set; }

        public Item Item { get; set; }

        public Page LinkedPage { get; set; }

        // TODO: add mappings
        public bool HasMappings
        {
            get { return false; }
        }

    }
}