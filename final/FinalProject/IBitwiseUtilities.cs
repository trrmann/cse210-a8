namespace FinalProject
{
    public interface IBitwiseUtilities
    {
        static int OptionCombination(List<Boolean> optionFlags)
        {
            int result = 0;
            int index = 0;
            optionFlags.ForEach(flag => {
                if (flag) result += (int)Math.Pow(2, index);
                index++;
            });
            return result;
        }
        static List<Boolean> OptionCombination(int optionFlags, int padTo = -1)
        {
            Boolean[] array;
            int remainder = optionFlags;
            int lb2 = ((int)Math.Log2(remainder))+1;
            if(padTo > 0 && lb2 < padTo) array = new Boolean[padTo];
            else array = new Boolean[lb2];
            for (int i = 0; i < lb2; i++) array[i] = false;
            lb2--;
            if (lb2 > -1) array[lb2] = true;
            while (remainder > 0)
            {
                remainder-= (int)Math.Pow(2, lb2);
                lb2 = (int)Math.Log2(remainder);
                if(lb2>-1) array[lb2] = true;
            }
            List<Boolean> result = new(array);
            return result;
        }
    }
}