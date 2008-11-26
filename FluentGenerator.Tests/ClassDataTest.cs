using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentGenerator.Extensions;
using NUnit.Framework;

namespace FluentGenerator.Tests
{
    [TestFixture]
    public class When_generating_a_class : Specification
    {
        [Test]
        public void Should_write_out_the_class_name()
        {
            ClassData data = new ClassData().WithName("Sample");
            data.Generate().IntoLines().First().Trim().ShouldBe("public class Sample");
        }

        [Test]
        public void Should_write_the_primary_key_property()
        {
            
        }
    }

    [TestFixture]
    public class When_generating_a_class_that_implements_INotifyPropertyChanging : Specification
    {
        [Test]
        public void Should_put_INotifyPropertyChanging_after_the_class_name()
        {
            ClassData data = new ClassData().WithName("Sample").WithPropertyChanging();
            data.Generate().IntoLines().First().Trim().ShouldBe("public class Sample : INotifyPropertyChanging");
        }
    }

    [TestFixture]
    public class When_generating_a_class_that_implements_INotifyPropertyChanged : Specification
    {
        [Test]
        public void Should_put_INotifyPropertyChanging_after_the_class_name()
        {
            ClassData data = new ClassData().WithName("Sample").WithPropertyChanging();
            data.Generate().IntoLines().First().Trim().ShouldBe("public class Sample : INotifyPropertyChanged");
        }
    }
}
