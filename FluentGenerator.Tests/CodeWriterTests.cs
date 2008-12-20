using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace FluentGenerator.Tests
{
    [TestFixture]
    public class When_using_the_CodeWriter : Specification
    {
        [Test]
        public void IncreaseIndent_should_increase_the_indent_by_the_number_of_spaces_set_in_IndentAmount()
        {
            CodeWriter writer = new CodeWriter();
            writer.IndentAmount = 6;
            writer.IncreaseIndent();
            writer.AppendLine("x");
            writer.ToString().ShouldBe("      x\r\n");
        }

        [Test]
        public void DecreaseIndent_should_decrease_the_indent_by_the_number_of_spaces_set_in_IndentAmount()
        {
            CodeWriter writer = new CodeWriter();
            writer.IndentAmount = 6;
            writer.IncreaseIndent();
            writer.DecreaseIndent();
            writer.AppendLine("x");
            writer.ToString().ShouldBe("x\r\n");
        }

        [Test]
        public void Should_indent_with_spaces_if_UseSpaces_is_true()
        {
            CodeWriter writer = new CodeWriter();
            writer.IndentAmount = 6;
            writer.UseSpaces = true;
            writer.IncreaseIndent();
            writer.AppendLine("x");
            writer.ToString().ShouldBe("      x\r\n");
        }

        [Test]
        public void Should_indent_with_tabs_if_UseSpaces_is_false()
        {
            CodeWriter writer = new CodeWriter();
            writer.IndentAmount = 6;
            writer.UseSpaces = false;
            writer.IncreaseIndent();
            writer.AppendLine("x");
            writer.ToString().ShouldBe("\tx\r\n");
            
        }
    }
}
