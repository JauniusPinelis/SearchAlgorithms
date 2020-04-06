using FluentAssertions;
using NUnit.Framework;
using SearchAlgorithms.Domain;
using System.Collections.Generic;

namespace SearchAlgorithms.DomainTests
{
	public class Tests
	{
		private readonly Solver _solver;
		public Tests()
		{
			_solver = new Solver();
		}

		[Test]
		public void GetMatchingPairUsingHash_GivenSentExample_FindsOneOfTheSums()
		{
			var numbers = new[] { 5, 5, 4, 3, 3, 0, 0, -1, -2, -3, -3 };
			int sum = 0;

			var result = _solver.GetMatchingPairUsingHash(numbers, sum);

			result.HasValue.Should().BeTrue();
			Assert.That(result, Is.AnyOf((0, 0), (3, -3), (-3, 3)));
		}

		[Test]
		public void GetMatchingPairUsingHash_ModifiedSentExample_FindTheSum()
		{
			var numbers = new[] { 5, 5, 4, 3, 3, 0, -1, -2, -3, -3 };
			var sum = 0;

			var result = _solver.GetMatchingPairUsingHash(numbers, sum);

			result.HasValue.Should().BeTrue();
			Assert.That(result, Is.AnyOf( (3, -3), (-3, 3)));
		}

		[Test]
		public void GetMatchingPairUsingHash_Given2SameNumbers_FindTheSum()
		{
			var numbers = new[] { 5, 5 };
			var sum = 10;

			var result = _solver.GetMatchingPairUsingHash(numbers, sum);

			result.HasValue.Should().BeTrue();
			result.Should().BeEquivalentTo((5, 5));
		}

		[Test]
		public void GetMatchingPairUsingHash_Given2Numbers_FailsToFindTheSum()
		{
			var numbers = new[] { 5, 6 };
			var sum = 10;

			var result = _solver.GetMatchingPairUsingHash(numbers, sum);

			result.HasValue.Should().BeFalse();
		}

		[Test]
		public void GetMatchingPairUsingWalkInwards_GivenSentExample_FindsTheSum()
		{
			var numbers = new[] { 5, 5, 4, 3, 3, 0, 0, -1, -2, -3, -3 };
			int sum = 0;

			var result = _solver.GetMatchingPairUsingWalkInwards(numbers, sum);

			result.HasValue.Should().BeTrue();
			Assert.That(result, Is.AnyOf((0, 0), (3, -3), (-3, 3)));
		}

		[Test]
		public void GetMatchingPairUsingWalkInwards_ModifiedSentExample_FindTheSum()
		{
			var numbers = new[] { 5, 5, 4, 3, 3, 0, -1, -2, -3, -3 };
			var sum = 0;

			var result = _solver.GetMatchingPairUsingWalkInwards(numbers, sum);

			result.HasValue.Should().BeTrue();
			Assert.That(result, Is.AnyOf((3, -3), (-3, 3)));
		}

		[Test]
		public void GetMatchingPairUsingWalkInwards_Given2SameNumbers_FindTheSum()
		{
			var numbers = new[] { 5, 5 };
			var sum = 10;

			var result = _solver.GetMatchingPairUsingWalkInwards(numbers, sum);

			result.HasValue.Should().BeTrue();
			result.Should().BeEquivalentTo((5, 5));
		}

		[Test]
		public void GetMatchingPairUsingWalkInwards_Given2Numbers_FailsToFindTheSum()
		{
			var numbers = new[] { 5, 6 };
			var sum = 10;

			var result = _solver.GetMatchingPairUsingWalkInwards(numbers, sum);

			result.HasValue.Should().BeFalse();
		}
	}
};