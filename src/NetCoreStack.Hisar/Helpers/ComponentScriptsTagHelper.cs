﻿using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetCoreStack.Hisar
{
    [HtmlTargetElement("component-scripts")]
    public class ComponentScriptsTagHelper : TagHelper
    {
        internal static readonly string ScriptsDictionaryKey = $"Hisar-{nameof(ComponentScriptsTagHelper)}";

        [ViewContext]
        public ViewContext ViewContext { get; set; }

        public ComponentScriptsTagHelper()
        {
        }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (output == null)
            {
                throw new ArgumentNullException(nameof(output));
            }

            // Always strip the outer tag name as we never want to render
            output.TagName = null;
            output.SuppressOutput();

            var tagHelperContent = await output.GetChildContentAsync();
            if (tagHelperContent != null)
            {
                if (ViewContext.HttpContext.Items.TryGetValue(ScriptsDictionaryKey, out object items))
                {
                    if (items is List<string> scripts)
                    {
                        scripts.Add(tagHelperContent.GetContent());
                    }
                }
                else
                {
                    ViewContext.HttpContext.Items[ScriptsDictionaryKey] = new List<string> { tagHelperContent.GetContent() };
                }
            }
        }
    }
}
