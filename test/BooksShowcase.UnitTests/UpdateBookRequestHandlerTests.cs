using BooksShowcase.Core;
using BooksShowcase.Core.Exceptions;
using BooksShowcase.Core.Handlers.Update;
using BooksShowcase.Core.Models.Entities;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;

namespace BooksShowcase.UnitTests;

public class UpdateBookRequestHandlerTests
{
    [Theory, AutoMoqData]
    public async Task ShouldClaimRevenueShare(Mock<IBooksWriter> booksWriter, Mock<IBooksReader> booksReader,
        Mock<ILogger<UpdateBookRequestHandler>> loggerMock, UpdateBookRequest request)
    {
        booksReader.Setup(r => r.GetBookById(request.Uuid)).ReturnsAsync(new Book());

        var updateBookHandler = new UpdateBookRequestHandler(booksWriter.Object, booksReader.Object, loggerMock.Object);

        await updateBookHandler.Handle(request, CancellationToken.None);

        booksWriter.Verify(w => w.UpdateBook(request), Times.Once);
    }
    
    [Theory, AutoMoqData]
    public void ShouldThrowIfNoBookExists(Mock<IBooksWriter> booksWriter, Mock<IBooksReader> booksReader,
        Mock<ILogger<UpdateBookRequestHandler>> loggerMock)
    {
        booksReader.Setup(r => r.GetBookById(It.IsAny<Guid>())).Returns(Task.FromResult<Book>(null!));
        
        var updateBookHandler = new UpdateBookRequestHandler(booksWriter.Object, booksReader.Object, loggerMock.Object);

        new Func<Task>(async () => await updateBookHandler.Handle(new UpdateBookRequest(), CancellationToken.None)).Should()
            .Throw<NotFoundException>();

        booksWriter.Verify(w => w.UpdateBook(It.IsAny<UpdateBookRequest>()), Times.Never);
    }
}