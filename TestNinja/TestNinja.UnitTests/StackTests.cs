using NUnit.Framework;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class StackTests
    {
        private Stack<object> _stack;

        [SetUp]
        public void SetUp()
        {
            _stack = new Stack<object>();
        }

        [Test]
        public void Push_UninitializedObjectPushedToStack_ThrowArgumentNullException()
        {
            Object obj = null;

            Assert.That(() => _stack.Push(obj), Throws.ArgumentNullException);
        }

        [Test]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void Push_WhenCalled_ReturnCountNumberEqualToNumerOfPushedObjects(int count)
        {
            for(int i = 0; i < count; i++)
            {
                _stack.Push(new object());
            }

            Assert.That(_stack.Count, Is.EqualTo(count));
        }

        [Test]
        public void Count_EmptyStack_ReturnZero()
        {
            Assert.That(_stack.Count, Is.EqualTo(0));
        }

        [Test]
        public void Pop_EmptyStack_ThrowInvalidOperationException()
        {
            Assert.That(() => _stack.Pop(), Throws.InvalidOperationException);
        }

        [Test]
        [TestCase(1, 0)]
        [TestCase(2, 1)]
        [TestCase(3, 2)]
        public void Pop_WhenCalled_ReturnNumberOfRemainingObjectsInStack(int count, int expectedCount)
        {
            for (int i = 0; i < count; i++)
            {
                _stack.Push(new object());
            }

            _stack.Pop();

            Assert.That(_stack.Count, Is.EqualTo(expectedCount));
        }

        [Test]
        public void Pop_OneElementInStack_ReturnsLastPushedElementToStack()
        {
            var obj = new object();
            _stack.Push(obj);

            var result = _stack.Pop();

            Assert.That(result, Is.EqualTo(obj));
        }

        [Test]
        public void Pop_AtLeastTwoElementsIn_ReturnsLastPushedElementToStack()
        {
            var obj = new object();
            var obj2 = new object();
            _stack.Push(obj);
            _stack.Push(obj2);

            var result = _stack.Pop();

            Assert.That(result, Is.EqualTo(obj2));
        }

        [Test]
        public void Peek_EmptyStack_ThrowInvalidOperationException()
        {
            Assert.That(() => _stack.Peek(), Throws.InvalidOperationException);
        }

        [Test]
        public void Peek_OneElementInStack_ReturnsLastPushedElementToStack()
        {
            var obj = new object();
            _stack.Push(obj);

            var result = _stack.Peek();

            Assert.That(result, Is.EqualTo(obj));
        }

        [Test]
        public void Peek_AtLeastTwoElementsInStack_ReturnsLastPushedElementToTheStack()
        {
            var obj = new object();
            var obj2 = new object();
            _stack.Push(obj);
            _stack.Push(obj2);

            var result = _stack.Peek();

            Assert.That(result, Is.EqualTo(obj2));
        }

        [Test]
        public void Peek_AtLeastTwoElementsIn_StackDoesNotRemoveObjectFromTheStack()
        {
            var obj = new object();
            var obj2 = new object();
            var obj3 = new object();
            _stack.Push(obj);
            _stack.Push(obj2);
            _stack.Push(obj3);

            _stack.Peek();

            Assert.That(_stack.Count, Is.EqualTo(3));
        }
    }
}
