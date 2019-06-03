using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Assignment5
{
    static class ExtensionMethods
    {
        
        // both this method and its overloaded version take full advantage of deferred execution
        //each value can be useful on its own and the whole collection does not need to be iterated over
        //in order to start returning values
        //so it uses yield return at each iteration to return the value if it is the greatest value in the collection so far
        public static IEnumerable<T> MaxOverPrevious<T>(this IEnumerable<T> values )
            where T : IComparable
        {
            T max = values.ElementAt(0) ;
            yield return max;

            foreach (T val in values)
            {
                if (val.CompareTo(max)>0)
                {
                    yield return val;
                    max = val;
                }
            }

            
        }
        //I know there was discussion on the slack whether or not to return the transformed values. I decided to return the
        //originals because I was thinking about my example of students and it seems no use to get back the transformed values
        //if I am sending in a collection of students with a func that transforms each of them to their numerical ID I still 
        //want back a collection of students- a collection of IDs is much less useful.(if someone really wants the transformed results
        //always apply the transformation and then call the extension method)
        public static IEnumerable<T> MaxOverPrevious<T>(this IEnumerable<T> values, Func<T, IComparable>transformer)
        {
            
            IComparable max = transformer(values.ElementAt(0));
            yield return values.ElementAt(0);

            foreach(T val in values)
            {
                IComparable temp = transformer(val);
                if (temp.CompareTo(max) > 0)
                {
                    yield return val;
                    max = temp;
                }
            }

     
        }

       //again both these methods use deferred exection and benefit from it 
       //if whoever uses the method only needs a few results then only those calculations are done
        public static IEnumerable<T> LocalMaxima<T>(this IEnumerable<T> values)
            where T : IComparable
        {

            T before = values.ElementAt(0);
            T current = values.ElementAt(0);
            T after = values.ElementAt(1);
            
            //takes care of first element
            if (before.CompareTo(after)>0)
            {
                yield return before;
            }

            //now rest of collection
            for(int c =1; c<values.Count()-1; c++){
                before =current;
                current = after;
                after = values.ElementAt(c + 1);
                if (current.CompareTo(before)>0 && current.CompareTo(after) > 0)
                {
                    yield return current;
                }
                
            }

            //deal with last one
            if (after.CompareTo(current) > 0)
            {
                yield return after;
            }

        }

        
        public static IEnumerable<T> LocalMaxima<T>(this IEnumerable<T> values, Func<T, IComparable> transformer)
        {
            IComparable before = transformer(values.ElementAt(0));
            IComparable current = transformer(values.ElementAt(0));
            IComparable after = transformer(values.ElementAt(1));

            //takes care of first element
            if (before.CompareTo(after) > 0)
            {
                yield return values.ElementAt(0);
            }

            //now rest of collection
            for (int c = 1; c < values.Count() - 1; c++)
            {
                before = current;
                current = after;
                after = transformer(values.ElementAt(c + 1));
                if (current.CompareTo(before) > 0 && current.CompareTo(after) > 0)
                {
                    yield return values.ElementAt(c);
                }

            }

            //deal with last one
            if (after.CompareTo(current) > 0)
            {
                yield return values.Last();
            }

        }

        //these methods dont return collections so there is no way to get any benefit from deferred execution
        //the closest thing to deferred execution in this case is at every iteration of the loop checking 
        //to see if "at least k" was reached yet or there arent enough iterations left to ever reach it
        //so it doesnt have to go through the whole input and apply the tester to each and then check if k was reached at the end
        //this also means the method is benefiting from the deferred execution of the values collection itself
        //because if it would anyway have to go throught the whole collection before the determination blocks
        // then it could have just transformed values to a list in the beginning
        public static bool AtLeastK<T>(this IEnumerable<T> values, int k, Func<T, bool> tester)
        {
            for (int c = 0; c < values.Count(); c++)
            {
                if (tester(values.ElementAt(c)))
                {
                    k--;
                }
                //reached condition
                if (k == 0)
                {
                   return true;
                }
                //know there is no way to reach condition
                else if (k-(values.Count()-(c+1))>0)
                {
                    return false;
                }
            }

           
                return false;
            

        }

        public static bool AtLeastHalf<T>(this T[] values, Func<T, bool> tester)
        {
            int k = values.Length / 2;
            return values.AtLeastK(k, tester);

        }



    }


    
}
