using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentGenerator.Extensions;
using NUnit.Framework;

namespace FluentGenerator.Tests
{
    public class Given_a_Generator : Specification
    {
        protected IGenerator _generator;
        protected ICodeWriter _codeWriter;

        protected override void Before_each()
        {
            base.Before_each();

            _generator = Stub<IGenerator>();
            _codeWriter = new CodeWriter();
        } 
    }

    [TestFixture]
    public class When_generating_a_class : Given_a_Generator
    {
        [Test]
        public void Should_write_out_the_class_name()
        {
            StringBuilder expected = new StringBuilder();
            expected.AppendLineFormat("public class Sample");
            expected.AppendLineFormat("{");
            expected.AppendLineFormat("}");

            ClassExpression data = new ClassExpression(_generator).WithName("Sample");
            data.Generate(_codeWriter);
            _codeWriter.ToString().ShouldBe(expected.ToString());
        }

        [Test]
        public void Should_write_the_primary_key_property()
        {
            StringBuilder expected = new StringBuilder();
            expected.AppendLineFormat("public class Sample");
            expected.AppendLineFormat("{");
            expected.AppendLineFormat("    public int PrimaryKey { get; set; }");
            expected.AppendLineFormat("}");

            ClassExpression data = new ClassExpression(_generator).WithName("Sample").AddPrimaryKeyProperty("PrimaryKey");
            data.Generate(_codeWriter);
            _codeWriter.ToString().ShouldBe(expected.ToString());
        }

        [Test]
        public void Should_write_out_properties_when_the_type_is_specified_as_a_string()
        {
            StringBuilder expected = new StringBuilder();
            expected.AppendLineFormat("public class Sample");
            expected.AppendLineFormat("{");
            expected.AppendLineFormat("    public abc Something { get; set; }");
            expected.AppendLineFormat("}");

            ClassExpression classExpression = new ClassExpression(_generator);
            classExpression.WithName("Sample").AddProperty("Something").OfType("abc");
            classExpression.Generate(_codeWriter);
            _codeWriter.ToString().ShouldBe(expected.ToString());
        }

        [Test]
        [ExpectedException(typeof(GenerationException))]
        public void Should_throw_exception_if_the_type_of_a_property_is_not_specified()
        {
            var classExpression = new ClassExpression(_generator);
            classExpression.WithName("Sample").AddProperty("abc");
            classExpression.Generate(_codeWriter);
        }

        [Test]
        [ExpectedException(typeof(GenerationException))]
        public void Should_throw_exception_if_the_name_of_a_property_is_not_specified()
        {
            var classExpression = new ClassExpression(_generator);
            classExpression.WithName("Sample").AddProperty((string) null).OfType("int");
            classExpression.Generate(_codeWriter);
        }

        [Test]
        public void Should_write_out_list_properties()
        {
            //StringBuilder expected = new StringBuilder();
            //expected.AppendLineFormat("public class Sample");
            //expected.AppendLineFormat("{");
            //expected.AppendLineFormat("    private List<abc> _someList = new List<abc>();");
            //expected.AppendLineFormat("");
            //expected.AppendLineFormat("    public IList<abc> SomeList");
            //expected.AppendLineFormat("    {");
            //expected.AppendLineFormat("        get { return _someList; }");
            //expected.AppendLineFormat("        set { _someList = value; }");
            //expected.AppendLineFormat("    }");
            //expected.AppendLineFormat("}");

            StringBuilder expected = new StringBuilder();
            expected.AppendLineFormat("public class Sample");
            expected.AppendLineFormat("{");
            expected.AppendLineFormat("    public IList<abc> SomeList { get; set; }");
            expected.AppendLineFormat("}");

            ClassExpression classExpression = new ClassExpression(_generator);
            classExpression.WithName("Sample").AddListOf("abc").WithName("SomeList");
            classExpression.Generate(_codeWriter);
            _codeWriter.ToString().ShouldBe(expected.ToString());
        }

        [Test]
        [ExpectedException(typeof(GenerationException))]
        public void Should_throw_exception_if_the_name_of_a_list_is_not_specified()
        {
            var classExpression = new ClassExpression(_generator);
            classExpression.WithName("Sample").AddListOf("abc");
            classExpression.Generate(_codeWriter);
        }

        [Test]
        [ExpectedException(typeof(GenerationException))]
        public void Should_throw_exception_if_the_type_of_a_list_is_not_specified()
        {
            var classExpression = new ClassExpression(_generator);
            classExpression.WithName("Sample").AddListOf(null).Of("int");
            classExpression.Generate(_codeWriter);
        }
    }

    //[TestFixture]
    //public class When_generating_a_class_that_implements_INotifyPropertyChanging : Given_a_Generator
    //{
    //    [Test]
    //    public void Should_implement_INotifyPropertyChanging()
    //    {
    //        StringBuilder expected = new StringBuilder();
    //        expected.AppendLineFormat("public partial class Sample : INotifyPropertyChanging");
    //        expected.AppendLineFormat("{");
    //        expected.AppendLineFormat("    public event PropertyChangingEventHandler PropertyChanging;");
    //        expected.AppendLineFormat("");
    //        expected.AppendLineFormat("    protected void NotifyPropertyChanging(string propertyName)");
    //        expected.AppendLineFormat("    {");
    //        expected.AppendLineFormat("        PropertyChangingEventArgs args = new PropertyChangingEventArgs(propertyName);");
    //        expected.AppendLineFormat("        OnNotifyPropertyChanging(args);");
    //        expected.AppendLineFormat("    }");
    //        expected.AppendLineFormat("");
    //        expected.AppendLineFormat("    protected virtual void OnNotifyPropertyChanging(PropertyChangingEventArgs e)");
    //        expected.AppendLineFormat("    {");
    //        expected.AppendLineFormat("        var handler = PropertyChanging;");
    //        expected.AppendLineFormat("        if (handler != null)");
    //        expected.AppendLineFormat("            handler(this, e);");
    //        expected.AppendLineFormat("    }");
    //        expected.AppendLineFormat("}");

    //        ClassExpression data = new ClassExpression(_generator).WithName("Sample").WithPropertyChanging();
    //        data.Generate(_codeWriter);
    //        _codeWriter.ToString().ShouldBe(expected.ToString());
    //    }

    //    [Test]
    //    public void Properties_should_call_NotifyPropertyChanging()
    //    {
    //        StringBuilder expected = new StringBuilder();
    //        expected.AppendLineFormat("public partial class Sample : INotifyPropertyChanging, INotifyPropertyChanged");
    //        expected.AppendLineFormat("{");
    //        expected.AppendLineFormat("    private string _something;");
    //        expected.AppendLineFormat("");
    //        expected.AppendLineFormat("    public event PropertyChangingEventHandler PropertyChanging;");
    //        expected.AppendLineFormat("");
    //        expected.AppendLineFormat("    public string Something");
    //        expected.AppendLineFormat("	   {");
    //        expected.AppendLineFormat("        get");
    //        expected.AppendLineFormat("        {");
    //        expected.AppendLineFormat("            return _something;");
    //        expected.AppendLineFormat("        }");
    //        expected.AppendLineFormat("        set");
    //        expected.AppendLineFormat("        {");
    //        expected.AppendLineFormat("            if ((_something != value))");
    //        expected.AppendLineFormat("            {");
    //        expected.AppendLineFormat("                NotifyPropertyChanging(\"Something\");");
    //        expected.AppendLineFormat("                _something = value;");
    //        expected.AppendLineFormat("            }");
    //        expected.AppendLineFormat("        }");
    //        expected.AppendLineFormat("    }");
    //        expected.AppendLineFormat("");
    //        expected.AppendLineFormat("    protected void NotifyPropertyChanging(string propertyName)");
    //        expected.AppendLineFormat("    {");
    //        expected.AppendLineFormat("        PropertyChangingEventArgs args = new PropertyChangingEventArgs(propertyName);");
    //        expected.AppendLineFormat("        OnNotifyPropertyChanging(args);");
    //        expected.AppendLineFormat("    }");
    //        expected.AppendLineFormat("");
    //        expected.AppendLineFormat("    protected virtual void OnNotifyPropertyChanging(PropertyChangingEventArgs e)");
    //        expected.AppendLineFormat("    {");
    //        expected.AppendLineFormat("        var handler = PropertyChanging;");
    //        expected.AppendLineFormat("        if (handler != null)");
    //        expected.AppendLineFormat("            handler(this, e);");
    //        expected.AppendLineFormat("    }");
    //        expected.AppendLineFormat("}");

    //        ClassExpression data = new ClassExpression(_generator).WithName("Sample").WithPropertyChanging();
    //        data.Generate(_codeWriter);
    //        _codeWriter.ToString().ShouldBe(expected.ToString());
    //    }
    //}

    //[TestFixture]
    //public class When_generating_a_class_that_implements_INotifyPropertyChanged : Given_a_Generator
    //{
    //    [Test]
    //    public void Should_implement_INotifyPropertyChanged()
    //    {
    //        StringBuilder expected = new StringBuilder();
    //        expected.AppendLineFormat("public partial class Sample : INotifyPropertyChanged");
    //        expected.AppendLineFormat("{");
    //        expected.AppendLineFormat("    public event PropertyChangedEventHandler PropertyChanged;");
    //        expected.AppendLineFormat("");
    //        expected.AppendLineFormat("    protected void NotifyPropertyChanged(string propertyName)");
    //        expected.AppendLineFormat("    {");
    //        expected.AppendLineFormat("        PropertyChangedEventArgs args = new PropertyChangedEventArgs(propertyName);");
    //        expected.AppendLineFormat("        OnNotifyPropertyChanged(args);");
    //        expected.AppendLineFormat("    }");
    //        expected.AppendLineFormat("");
    //        expected.AppendLineFormat("    protected virtual void OnNotifyPropertyChanged(PropertyChangedEventArgs e)");
    //        expected.AppendLineFormat("    {");
    //        expected.AppendLineFormat("        var handler = PropertyChanged;");
    //        expected.AppendLineFormat("        if (handler != null)");
    //        expected.AppendLineFormat("            handler(this, e);");
    //        expected.AppendLineFormat("    }");
    //        expected.AppendLineFormat("}");

    //        ClassExpression data = new ClassExpression(_generator).WithName("Sample").WithPropertyChanged();
    //        data.Generate(_codeWriter);
    //        _codeWriter.ToString().ShouldBe(expected.ToString());
    //    }

    //    [Test]
    //    public void Properties_should_call_NotifyPropertyChanged()
    //    {
    //        StringBuilder expected = new StringBuilder();
    //        expected.AppendLineFormat("public partial class Sample : INotifyPropertyChanged, INotifyPropertyChanged");
    //        expected.AppendLineFormat("{");
    //        expected.AppendLineFormat("    private string _something;");
    //        expected.AppendLineFormat("");
    //        expected.AppendLineFormat("    public event PropertyChangedEventHandler PropertyChanged;");
    //        expected.AppendLineFormat("");
    //        expected.AppendLineFormat("    public string Something");
    //        expected.AppendLineFormat("	   {");
    //        expected.AppendLineFormat("        get");
    //        expected.AppendLineFormat("        {");
    //        expected.AppendLineFormat("            return _something;");
    //        expected.AppendLineFormat("        }");
    //        expected.AppendLineFormat("        set");
    //        expected.AppendLineFormat("        {");
    //        expected.AppendLineFormat("            if ((_something != value))");
    //        expected.AppendLineFormat("            {");
    //        expected.AppendLineFormat("                _something = value;");
    //        expected.AppendLineFormat("                NotifyPropertyChanged(\"Something\");");
    //        expected.AppendLineFormat("            }");
    //        expected.AppendLineFormat("        }");
    //        expected.AppendLineFormat("    }");
    //        expected.AppendLineFormat("");
    //        expected.AppendLineFormat("    protected void NotifyPropertyChanged(string propertyName)");
    //        expected.AppendLineFormat("    {");
    //        expected.AppendLineFormat("        PropertyChangedEventArgs args = new PropertyChangedEventArgs(propertyName);");
    //        expected.AppendLineFormat("        OnNotifyPropertyChanged(args);");
    //        expected.AppendLineFormat("    }");
    //        expected.AppendLineFormat("");
    //        expected.AppendLineFormat("    protected virtual void OnNotifyPropertyChanged(PropertyChangedEventArgs e)");
    //        expected.AppendLineFormat("    {");
    //        expected.AppendLineFormat("        var handler = PropertyChanged;");
    //        expected.AppendLineFormat("        if (handler != null)");
    //        expected.AppendLineFormat("            handler(this, e);");
    //        expected.AppendLineFormat("    }");
    //        expected.AppendLineFormat("}");

    //        ClassExpression data = new ClassExpression(_generator).WithName("Sample").WithPropertyChanged().AddProperty("Something").OfType("string");
    //        data.Generate(_codeWriter);
    //        _codeWriter.ToString().ShouldBe(expected.ToString());
    //    }
    //}

    //[TestFixture]
    //public class When_generating_a_class_that_implements_INotifyPropertyChanging_and_INotifyPropertyChanged : Given_a_Generator
    //{
    //    [Test]
    //    public void Should_implement_INotifyPropertyChanging_and_INotifyPropertyChanged()
    //    {
    //        StringBuilder expected = new StringBuilder();
    //        expected.AppendLineFormat("public partial class Sample : INotifyPropertyChanging, INotifyPropertyChanged");
    //        expected.AppendLineFormat("{");
    //        expected.AppendLineFormat("    public event PropertyChangingEventHandler PropertyChanging;");
    //        expected.AppendLineFormat("    public event PropertyChangedEventHandler PropertyChanged;");
    //        expected.AppendLineFormat("");
    //        expected.AppendLineFormat("    protected void NotifyPropertyChanging(string propertyName)");
    //        expected.AppendLineFormat("    {");
    //        expected.AppendLineFormat("        PropertyChangingEventArgs args = new PropertyChangingEventArgs(propertyName);");
    //        expected.AppendLineFormat("        OnNotifyPropertyChanging(args);");
    //        expected.AppendLineFormat("    }");
    //        expected.AppendLineFormat("");
    //        expected.AppendLineFormat("    protected void NotifyPropertyChanged(string propertyName)");
    //        expected.AppendLineFormat("    {");
    //        expected.AppendLineFormat("        PropertyChangedEventArgs args = new PropertyChangedEventArgs(propertyName);");
    //        expected.AppendLineFormat("        OnNotifyPropertyChanged(args);");
    //        expected.AppendLineFormat("    }");
    //        expected.AppendLineFormat("");
    //        expected.AppendLineFormat("    protected virtual void OnNotifyPropertyChanging(PropertyChangingEventArgs e)");
    //        expected.AppendLineFormat("    {");
    //        expected.AppendLineFormat("        var handler = PropertyChanging;");
    //        expected.AppendLineFormat("        if (handler != null)");
    //        expected.AppendLineFormat("            handler(this, e);");
    //        expected.AppendLineFormat("    }");
    //        expected.AppendLineFormat("");
    //        expected.AppendLineFormat("    protected virtual void OnNotifyPropertyChanged(PropertyChangedEventArgs e)");
    //        expected.AppendLineFormat("    {");
    //        expected.AppendLineFormat("        var handler = PropertyChanged;");
    //        expected.AppendLineFormat("        if (handler != null)");
    //        expected.AppendLineFormat("            handler(this, e);");
    //        expected.AppendLineFormat("    }");
    //        expected.AppendLineFormat("}");

    //        ClassExpression data = new ClassExpression(_generator).WithName("Sample").WithPropertyChanging().WithPropertyChanged();
    //        data.Generate(_codeWriter);
    //        _codeWriter.ToString().ShouldBe(expected.ToString());
    //    }

    //    [Test]
    //    public void Properties_should_call_NotifyPropertyChanging_and_NotifyPropertyChanged()
    //    {
    //        StringBuilder expected = new StringBuilder();
    //        expected.AppendLineFormat("public partial class Sample : INotifyPropertyChanging, INotifyPropertyChanged");
    //        expected.AppendLineFormat("{");
    //        expected.AppendLineFormat("    private string _something;");
    //        expected.AppendLineFormat("");
    //        expected.AppendLineFormat("    public event PropertyChangingEventHandler PropertyChanging;");
    //        expected.AppendLineFormat("    public event PropertyChangedEventHandler PropertyChanged;");
    //        expected.AppendLineFormat("");
    //        expected.AppendLineFormat("    public string Something");
    //        expected.AppendLineFormat("	   {");
    //        expected.AppendLineFormat("        get");
    //        expected.AppendLineFormat("        {");
    //        expected.AppendLineFormat("            return _something;");
    //        expected.AppendLineFormat("        }");
    //        expected.AppendLineFormat("        set");
    //        expected.AppendLineFormat("        {");
    //        expected.AppendLineFormat("            if ((_something != value))");
    //        expected.AppendLineFormat("            {");
    //        expected.AppendLineFormat("                NotifyPropertyChanging(\"Something\");");
    //        expected.AppendLineFormat("                _something = value;");
    //        expected.AppendLineFormat("                NotifyPropertyChanged(\"Something\");");
    //        expected.AppendLineFormat("            }");
    //        expected.AppendLineFormat("        }");
    //        expected.AppendLineFormat("    }");
    //        expected.AppendLineFormat("");
    //        expected.AppendLineFormat("    protected void NotifyPropertyChanging(string propertyName)");
    //        expected.AppendLineFormat("    {");
    //        expected.AppendLineFormat("        PropertyChangingEventArgs args = new PropertyChangingEventArgs(propertyName);");
    //        expected.AppendLineFormat("        OnNotifyPropertyChanging(args);");
    //        expected.AppendLineFormat("    }");
    //        expected.AppendLineFormat("");
    //        expected.AppendLineFormat("    protected void NotifyPropertyChanged(string propertyName)");
    //        expected.AppendLineFormat("    {");
    //        expected.AppendLineFormat("        PropertyChangedEventArgs args = new PropertyChangedEventArgs(propertyName);");
    //        expected.AppendLineFormat("        OnNotifyPropertyChanged(args);");
    //        expected.AppendLineFormat("    }");
    //        expected.AppendLineFormat("");
    //        expected.AppendLineFormat("    protected virtual void OnNotifyPropertyChanging(PropertyChangingEventArgs e)");
    //        expected.AppendLineFormat("    {");
    //        expected.AppendLineFormat("        var handler = PropertyChanging;");
    //        expected.AppendLineFormat("        if (handler != null)");
    //        expected.AppendLineFormat("            handler(this, e);");
    //        expected.AppendLineFormat("    }");
    //        expected.AppendLineFormat("");
    //        expected.AppendLineFormat("    protected virtual void OnNotifyPropertyChanged(PropertyChangedEventArgs e)");
    //        expected.AppendLineFormat("    {");
    //        expected.AppendLineFormat("        var handler = PropertyChanged;");
    //        expected.AppendLineFormat("        if (handler != null)");
    //        expected.AppendLineFormat("            handler(this, e);");
    //        expected.AppendLineFormat("    }");
    //        expected.AppendLineFormat("}");

    //        ClassExpression data = new ClassExpression(_generator).WithName("Sample").WithPropertyChanging().WithPropertyChanged().AddProperty("Something").OfType("string");
    //        data.Generate(_codeWriter);
    //        _codeWriter.ToString().ShouldBe(expected.ToString());
    //    }
    //}

}


