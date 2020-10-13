namespace System
{
    public static class SystemExtensions
    {
        public static void ReverseWords(char[] chars)
        {
            if (chars == null)
            {
                return;
            }

            // First we need to reverse all the characters in the entire input
            ReverseCharacters(chars, 0, chars.Length - 1);

            // Now the input is in the right word order, but every word is backward
            // Now we'll make the words forward again by reversing each word's characters

            // We hold the index of the start of the current word as we look for the end of the current word
            const char wordBreak = ' ';
            int currentWordStartIndex = 0;
            for (int i = 0; i <= chars.Length; i++)
            {
                // Found the end of the current word
                if (i == chars.Length || chars[i] == wordBreak)
                {
                    // If we haven't exhausted the array, our next word's start is i+1
                    ReverseCharacters(chars, currentWordStartIndex, i-1);
                    currentWordStartIndex = i + 1;
                }
            }
        }

        private static void ReverseCharacters(char[] chars, int leftIndex, int rightIndex)
        {
            if (chars == null)
            {
                return;
            }

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
