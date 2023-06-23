using Moq;
using ProjetoValidacao.Models;

namespace ProjetoValidacao.Teste
{
    [TestFixture]
    public class Tests
    {
        private Mock<AppDbContext> _context;

        [SetUp]
        public void Setup()
        {
            _context = new Mock<AppDbContext>();
        }

        [Test]
        public void Test()
        {
            var model = new Conta() { Nome = It.IsAny<string>(), Descricao = It.IsAny<string>() };
            //_context.Setup(x => x.Add(It.IsAny<Conta>())).Returns();
            Assert.Pass();
        }
    }
}