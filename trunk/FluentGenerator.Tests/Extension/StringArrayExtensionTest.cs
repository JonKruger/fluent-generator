using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentGenerator.Extensions;
using NUnit.Framework;

namespace FluentGenerator.Tests.Extension
{
    [TestFixture]
    public class When_calling_After : Specification
    {
        [Test]
        public void Should_return_all_of_the_lines_after_the_last_line_that_has_the_value()
        {
            string[] lines = new[] {"asdf", "qwer", "zxcv"};
            string[] after = lines.After("we");
            after.Count().ShouldBe(1);
            after.First().ShouldBe("zxcv");
        }

        [Test]
        public void Should_return_all_of_the_lines_if_no_line_has_the_value()
        {
            string[] lines = new[] { "asdf", "qwer", "zxcv" };
            string[] after = lines.After("1234");
            after.Intersect(lines).Count().ShouldBe(3);
        }

        [Test]
        public void Should_return_an_empty_array_if_the_last_line_has_the_value()
        {
            string[] lines = new[] { "asdf", "qwer", "zxcv" };
            string[] after = lines.After("z");
            after.Count().ShouldBe(0);
        }
    }
}
