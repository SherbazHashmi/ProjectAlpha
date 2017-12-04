using UnityEngine;
using System.Collections;


namespace MoreMountains.CorgiEngine
{
    public class TalentTree
    {
        Node tree;
        int elements;

        class Node
        {
            Talent element;
            Node left, right;

            Node find (Talent element) {

                return null;
            }

            Node add (Talent element) {
                return null;
            }

            Node add (Node node) {
                return null;
            }

			public string toString()
			{
				if (element == null)
					return "";
				return ((left == null) || (left.element == null) ? "" : (left + ", ")) +
						element.toString() +
						((right == null || right.element == null) ? "" : (", " + right));
			}
        }
    }
}
