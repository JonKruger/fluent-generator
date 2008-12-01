using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentGenerator.Extensions;

namespace FluentGenerator.Tests.Extension
{
    public class When_splitting_strings_into_lines : Specification
    {
        public void Should_split_on_line_breaks()
        {
            string s = "asdf\r\nqwer";
            var splits = s.ToLinesArray();

            splits.Count().ShouldBe(2);
            splits[0].ShouldBe("asdf");
            splits[1].ShouldBe("qwer");
        }

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
}
