using System;
using System.Collections.Generic;
using System.Linq;

namespace NUnit.Framework
{
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
	public class ScenarioAttribute : TestFixtureAttribute { }

	[AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
	public class WhenAttribute : SetUpAttribute { }

	[AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
	public class GivenAttribute : SetUpAttribute { }

	[AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
	public class ThenAttribute : TestAttribute { }

	public static class Assertions
	{
		#region Uniary
		public static void should_be_ignored(this object anything)
		{
			Assert.Ignore("Ignored");
		}

		public static void should_be_true(this bool condition)
		{
			Assert.That(condition, Is.True);
		}

		public static void should_be_false(this bool condition)
		{
			Assert.That(condition, Is.False);
		}

		public static void should_be_null(this object value)
		{
			Assert.That(value, Is.Null);
		}

		public static void should_not_be_null(this object value)
		{
			Assert.That(value, Is.Not.Null);
		}

		public static void should_be_empty(this string value)
		{
			Assert.That(value, Is.Empty);
		}

		public static void should_not_be_empty(this string value)
		{
			Assert.That(value, Is.Not.Empty);
		}

		public static void should_be_empty(this IEnumerable<object> collection)
		{
			Assert.That(collection.Any(), Is.False);
		}

		public static void should_not_be_empty(this IEnumerable<object> collection)
		{
			Assert.That(collection.Any(), Is.True);
		}

		public static void should_be_instance_of<T>(this object actual)
		{
			Assert.That(actual, Is.InstanceOf(typeof(T)));
		}

		public static void should_not_be_instance_of<T>(this object actual)
		{
			Assert.That(actual, Is.Not.InstanceOf(typeof(T)));
		}

		public static void should_be_of_type<T>(this Type t)
		{
			Assert.That(t.FullName, Is.EqualTo(typeof(T).FullName)); // Compare by full name because reflection tends to wrap in RuntimeType
		}

		#endregion

		public static void should_be_equal_to(this object actual, object expected)
		{
			Assert.That(actual, Is.EqualTo(expected));
		}

		public static void should_not_be_equal_to(this object actual, object expected)
		{
			Assert.That(actual, Is.Not.EqualTo(expected));
		}

		public static void should_be_the_same_as(this object actual, object expected)
		{
			Assert.That(actual, Is.SameAs(expected));
		}

		public static void should_not_be_the_same_as(this object actual, object expected)
		{
			Assert.That(actual, Is.Not.SameAs(expected));
		}

		public static void should_be_greater_than(this IComparable actual, IComparable baseline)
		{
			Assert.That(actual, Is.GreaterThan(baseline));
		}

		public static void should_be_greater_than_or_equal_to(this IComparable actual, IComparable baseline)
		{
			Assert.That(actual, Is.GreaterThanOrEqualTo(baseline));
		}

		public static void should_be_less_than(this IComparable actual, IComparable baseline)
		{
			Assert.That(actual, Is.LessThan(baseline));
		}

		public static void should_be_less_than_or_equal_to(this IComparable actual, IComparable baseline)
		{
			Assert.That(actual, Is.LessThanOrEqualTo(baseline));
		}

		public static void should_be_instance_of(this object actual, Type type)
		{
			Assert.That(actual, Is.InstanceOf(type));
		}

		public static void should_contain(this string actual, string expected)
		{
			Assert.That(actual.Contains(expected), Is.True);
		}

		public static void should_not_contain(this string actual, string expected)
		{
			Assert.That(actual.Contains(expected), Is.Not.True);
		}

		public static void should_contain(this IEnumerable<object> actual, object expected)
		{
			Assert.That(actual.Contains(expected), Is.True);
		}

		public static void should_not_contain(this IEnumerable<object> actual, object expected)
		{
			Assert.That(actual.Contains(expected), Is.Not.True);
		}

		public static void should_contain<T>(this IEnumerable<T> actual, Func<T, bool> predicate)
		{
			Assert.That(actual.Any(predicate.Invoke), Is.True);
		}

		public static void should_not_contain<T>(this IEnumerable<T> actual, Func<T, bool> predicate)
		{
			Assert.That(actual.Any(predicate.Invoke), Is.Not.True);
		}

		public static void should_contain_the_same_elements_as<T>(this IEnumerable<T> actual, IEnumerable<T> expected)
		{
			var a = actual.ToArray();
			var b = expected.ToArray();
			(a.All(b.Contains)
			 && b.All(a.Contains)).should_be_true();
		}

		public static void should_contain_the_same_sequence_as<T>(this IEnumerable<T> actual, IEnumerable<T> expected)
		{
			Assert.That(actual.SequenceEqual(expected), Is.True);
		}
	}
}
