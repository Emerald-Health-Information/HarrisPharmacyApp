using System;
using System.Collections.Generic;
using Xunit;
using Egil.RazorComponents.Testing;
using Egil.RazorComponents.Testing.Diffing;
using Egil.RazorComponents.Testing.Asserting;
using Egil.RazorComponents.Testing.EventDispatchExtensions;
using HarrisPharmacy.App.Shared.Components;

namespace HarrisPharmacy.RazorComponentTests
{
    public class SelectListComponentTest : ComponentTestFixture
    {
        public Dictionary<string, string>
            ValuesDictionary = new Dictionary<string, string>();

        /// <summary>
        /// A test to make sure the select list component is rendering correctly
        /// </summary>
        [Fact]
        public void SelectListComponentRendersCorrectly()
        {
            ValuesDictionary.Add("test", "test");
            ComponentParameter[] parameters = { ComponentParameter.CreateParameter("ValuesDictionary", ValuesDictionary), ComponentParameter.CreateParameter("Name", "test") };
            var cut = RenderComponent<SelectListComponent>(parameters);
            cut.MarkupMatches(@"<div class=""input-group pt-1"" data-target-input=""nearest"">
  <select class=""form-control"">
    <option>Select test</option>
    <option value=""test"">test</option>
  </select>
</div>");
        }
    }
}