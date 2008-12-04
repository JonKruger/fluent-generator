using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentGenerator.Extensions;
using NUnit.Framework;

namespace FluentGenerator.Tests.Extension
{
    [TestFixture]
    public class When_splitting_strings_into_lines : Specification
    {
        [Test]
        public void Should_split_on_line_breaks()
        {
            string s = "asdf\r\nqwer";
            var splits = s.ToLinesArray();

            splits.Count().ShouldBe(2);
            splits[0].ShouldBe("asdf");
            splits[1].ShouldBe("qwer");
        }

        [Test]
        public void Should_return_empty_string_for_empty_lines()
        {
            string s = "asdf\r\n\r\nqwer";
            var splits = s.ToLinesArray();

            splits.Count().ShouldBe(3);
            splits[0].ShouldBe("asdf");
            splits[1].ShouldBe("");
            splits[2].ShouldBe("qwer");
        }
    }

    [TestFixture]
    public class When_calling_ToCamelCaseUnderscore : Specification
    {
        [Test]
        public void Should_return_null_if_null_is_passed()
        {
            StringExtension.ToCamelCaseUnderscore(null).ShouldBeNull();   
        }

        [Test]
        public void Should_return_empty_string_if_empty_string_is_passed()
        {
            "".ToCamelCaseUnderscore().ShouldBe("");
        }

        [Test]
        public void Should_return_the_same_string_if_the_string_starts_with_an_underscore()
        {
            "_yo".ToCamelCaseUnderscore().ShouldBe("_yo");
        }

        [Test]
        public void Should_add_underscore_and_change_first_character_to_lowercase_if_there_is_only_one_character_in_the_string()
        {
            "K".ToCamelCaseUnderscore().ShouldBe("_k");
        }

        [Test]
        public void Should_add_underscore_and_change_first_character_to_lowercase()
        {
            "LeBronJames".ToCamelCaseUnderscore().ShouldBe("_leBronJames");
        }
    }
}
