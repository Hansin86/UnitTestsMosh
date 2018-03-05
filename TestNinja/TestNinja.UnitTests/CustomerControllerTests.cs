using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class CustomerControllerTests
    {
        [Test]
        public void GetCustomer_IdIsZero_ReturnNotFound()
        {
            var controller = new CustomerController();

            var result = controller.GetCustomer(0);

            //result is exactly NotFound object            
            Assert.That(result, Is.TypeOf<NotFound>());

            //result is NotFound object or one of the derivatives of NotFound object
            //Assert.That(result, Is.InstanceOf<NotFound>()); 
        }

        [Test]
        public void GetCustomer_IdNotZero_ReturnOk()
        {

        }

        
    }
}
