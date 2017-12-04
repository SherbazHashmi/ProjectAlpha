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

            Node find(Talent element)
            {

                if (element == null || this.element == null) {
                    return null;
                } else if (this.element == element) {
                    return this; /// FOUND IT! 
                } else if (element.hashCode() < this.element.hashCode() {
                    if (left != null)
                        find(left); 
                } else {
                    if (right != null)
                        find(right); 
                }
            }


            Node add(Talent element) {
                    if (element == null) {
                        return null;
                    } else if (this.element == null) {
                        return this.element = element; /// Added it.
                    } else if (element.hashCode() < this.element.hashCode()) {
                        if (left == null)
                            left = new Node();
                        left.add(element);
                    } else {
                    if (right == null)
                        right = new Node();
                    right.add(element);

            }

            Node add (Node node) {
                return null;
            }

		string toString()

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
