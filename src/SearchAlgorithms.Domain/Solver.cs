using System;
using System.Collections.Generic;

namespace SearchAlgorithms.Domain
{
	public class Solver
	{
		public (int, int)? GetMatchingPairUsingHash(int[] arr, int x)
		{
			HashSet<int> values = new HashSet<int>();
			for (int i = 0; i < arr.Length; i++)
			{
				if (values.Contains(x - arr[i])) return (x - arr[i], arr[i]);
				values.Add(arr[i]);
			}

			return null;
		}

		public (int, int)? GetMatchingPairUsingWalkInwards(int[] arr, int x)
		{
			var left = 0;
			var right = arr.Length - 1;
				while (left < right)
				{
					int sum = arr[left] + arr[right];
					if (sum == x) return (arr[left] , arr[right]);
					else if (sum > x) left++;
					else right--;
				}
			return null;
		}
	}
}
