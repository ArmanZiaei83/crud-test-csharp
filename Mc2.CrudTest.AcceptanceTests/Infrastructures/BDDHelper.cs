using System;
using System.Linq;
using System.Linq.Expressions;
using Mc2.CrudTest.Infrastructure.Shared.Extensions;

namespace Mc2.CrudTest.AcceptanceTests.Infrastructures
{
    public static class Runner
    {
        public static void RunScenario(
            params Expression<Action<object>>[] steps)
        {
            var textContext = new
            {
            };

            steps.Select(_ => _.Compile()).ForEach(_ => _.Invoke(textContext));
        }
    }

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class Scenario : Attribute
    {
        public Scenario(string title)
        {
            Title = title;
        }

        public string Title { get; set; }
    }

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class Given : Attribute
    {
        public Given(string title)
        {
            Title = title;
        }

        private string Title { get; }
    }

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class When : Attribute
    {
        public When(string title)
        {
            Title = title;
        }

        private string Title { get; }
    }

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class Then : Attribute
    {
        public Then(string title)
        {
            Title = title;
        }

        private string Title { get; }
    }
}