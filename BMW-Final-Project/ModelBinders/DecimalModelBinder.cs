using System.Globalization;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BMW_Final_Project.ModelBinders
{
    public class DecimalModelBinder : IModelBinder
    {

        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            ValueProviderResult result = bindingContext.ValueProvider
                .GetValue(bindingContext.ModelName);

            if (result != ValueProviderResult.None && !string.IsNullOrEmpty(result.FirstValue))
            {
                decimal res = 0m;
                bool success = false;

                try
                {
                    string strValue = result.FirstValue.Trim();
                    strValue = strValue.Replace(",", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
                    strValue = strValue.Replace(".", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);

                    res = Convert.ToDecimal(strValue,CultureInfo.CurrentCulture);

                    success = true;

                }
                catch (FormatException fx)
                {
                    bindingContext.ModelState.AddModelError(bindingContext.ModelName,fx,bindingContext.ModelMetadata);
                }

                if (success)
                {
                    bindingContext.Result = ModelBindingResult.Success(res);
                }

            }

            return Task.CompletedTask;
        }
    }
}
