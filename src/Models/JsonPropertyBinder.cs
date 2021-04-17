// Copyright (c) DealerVision.com All rights reserved.
// JsonPropertyBinder.cs in DealerVision.Components.Web

using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;

namespace DealerVision.Components.Web.Models
{
    /// <summary>
    ///     Useful for when a model is posted as form or url encoded but you still want to
    ///     deserialize a property as json.
    /// </summary>
    public class JsonPropertyBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }

            // Fetch the value of the argument by name and set it to the model state

            var valueProviderResult = bindingContext.ValueProvider.GetValue(bindingContext.FieldName);

            if (valueProviderResult == ValueProviderResult.None)
            {
                return Task.CompletedTask;
            }

            bindingContext.ModelState.SetModelValue(bindingContext.FieldName, valueProviderResult);

            // Do nothing if the value is null or empty
            var value = valueProviderResult.FirstValue;

            if (string.IsNullOrEmpty(value))
            {
                return Task.CompletedTask;
            }

            try
            {
                // Deserialize the provided value and set the binding result

                var result = JsonConvert.DeserializeObject(value, bindingContext.ModelType);

                bindingContext.Result = ModelBindingResult.Success(result);
            }
            catch (JsonException)
            {
                bindingContext.Result = ModelBindingResult.Failed();
            }

            return Task.CompletedTask;
        }
    }
}