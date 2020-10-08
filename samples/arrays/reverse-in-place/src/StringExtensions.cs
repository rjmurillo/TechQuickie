using System;

// ReSharper disable CheckNamespace
// We want this to be available as an extension when including the System namespace.
namespace System
// ReSharper restore CheckNamespace
{
    public static class SystemExtensions
    {
        public static void Reverse(char[] chars)
        {
            if (chars == null)
            {
                return;
            }

            int leftIndex = 0,
                rightIndex = chars.Length - 1;

            // We swap the first and last characters, then the second and second to last until we reach the middle
            while (leftIndex < rightIndex)
            {
                // Swap
                char temp = chars[leftIndex];
                chars[leftIndex] = chars[rightIndex];
                chars[rightIndex] = temp;

                // Move towards the middle
                leftIndex++;
                rightIndex--;
            }
        }
    }
}
