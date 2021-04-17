// Copyright (c) DealerVision.com All rights reserved.
// DealerViewModel.cs in DealerVision.Components.Web

using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace DealerVision.Components.Web.Models
{
    public class DealerViewModel
    {
        public int Id { get; set; }

        [Required] public string Name { get; set; }

        public string PhoneNumber { get; set; }

        /// <summary>
        ///     Identifies this field as json-serialized even when the rest of the
        ///     model is form or url encoded. All my attempts to use other attributes
        ///     like [JsonConverter] didn't work because the request type wasn't json.
        /// </summary>
        [ModelBinder(typeof(JsonPropertyBinder))]
        public IList<string> EmailList1 { get; set; } = new List<string>();

        /// <summary>
        ///     Identifies this field as json-serialized even when the rest of the
        ///     model is form or url encoded. All my attempts to use other attributes
        ///     like [JsonConverter] didn't work because the request type wasn't json.
        /// </summary>
        [ModelBinder(typeof(JsonPropertyBinder))]
        public IList<string> EmailList2 { get; set; } = new List<string>();
    }
}