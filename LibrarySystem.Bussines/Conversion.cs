using DataAcess.Data.Models;
using LibrarySystem.Data.Data;
using LibrarySystem.Models;
using System;
using System.Linq;

namespace LibrarySystem.Business
{
    /// <summary>
    /// Represent a class for converting between Data and DTO data types.
    /// </summary>
    public static class Conversion
    {
        internal static Title ConvertTitle(TitleDto title)
        {
            if (title is null)
            {
                throw new ArgumentNullException(nameof(title));
            }

            var result = new Title
            {
                Id = title.Id,
                Description = title.Description,
                ImageContent = title.ImageContent,
                ImageName = title.ImageName,
                Isbn = title.Isbn,
                Name = title.Name,
                Publisher = title.Publisher,
                ReleaseYear = title.ReleaseYear,
                Section = title.Section,
                TitleImages = title.TitleImages.Select(ConvertImage).ToList(),
                Type = title.Type,
                Writer = title.Writer,
            };

            return result;
        }

        internal static Image ConvertImage(ImageDto image)
        {
            if (image is null)
            {
                throw new ArgumentNullException(nameof(image));
            }

            var result = new Image
            {
                Id = image.Id,
                BookId = image.BookId,
                BookImageUrl = image.BookImageUrl,
            };

            return result;
        }

        internal static TitleDto ConvertTitle(Title title)
        {
            if (title is null)
            {
                throw new ArgumentNullException(nameof(title));
            }

            var result = new TitleDto
            {
                Id = title.Id,
                Description = title.Description,
                ImageContent = title.ImageContent,
                ImageName = title.ImageName,
                Isbn = title.Isbn,
                Name = title.Name,
                Publisher = title.Publisher,
                ReleaseYear = title.ReleaseYear,
                Section = title.Section,
                TitleImages = title.TitleImages.Select(ConvertImage).ToList(),
                Type = title.Type,
                Writer = title.Writer,
            };

            return result;
        }

        internal static ImageDto ConvertImage(Image image)
        {
            if (image is null)
            {
                throw new ArgumentNullException(nameof(image));
            }

            var result = new ImageDto
            {
                Id = image.Id,
                BookId = image.BookId,
                BookImageUrl = image.BookImageUrl,
            };

            return result;
        }

        internal static LibraryBook ConvertBook(LibraryBookDto book)
        {
            if (book is null)
            {
                throw new ArgumentNullException(nameof(book));
            }

            var result = new LibraryBook
            {
                Id = book.Id,
                Name = book.Name,
                Bearer = book.Bearer,
                Condition = book.Condition,
                Stock = book.Stock,
            };

            return result;
        }

        internal static LibraryBookDto ConvertBook(LibraryBook book)
        {
            if (book is null)
            {
                throw new ArgumentNullException(nameof(book));
            }

            var result = new LibraryBookDto
            {
                Id = book.Id,
                Name = book.Name,
                Bearer = book.Bearer,
                Condition = book.Condition,
                Stock = book.Stock,
            };

            return result;
        }

        internal static SectionDto ConvertSection(Section section)
        {
            if (section is null)
            {
                throw new ArgumentNullException(nameof(section));
            }

            var result = new SectionDto
            {
                Id = section.Id,
                Name = section.Name,
                Book = section.Book,
                Description = section.Description,
            };

            return result;
        }

        internal static Section ConvertSection(SectionDto section)
        {
            if (section is null)
            {
                throw new ArgumentNullException(nameof(section));
            }

            var result = new Section
            {
                Id = section.Id,
                Name = section.Name,
                Book = section.Book,
                Description = section.Description,
            };

            return result;
        }

        internal static Title ConvertUpdate(Title title, TitleDto bookDetails)
        {

            title.Id = bookDetails.Id;
            title.Description = bookDetails.Description;
            title.ImageContent = bookDetails.ImageContent;
            title.ImageName = bookDetails.ImageName;
            title.Isbn = bookDetails.Isbn;
            title.Name = bookDetails.Name;
            title.Publisher = bookDetails.Publisher;
            title.ReleaseYear = bookDetails.ReleaseYear;
            title.Section = bookDetails.Section;
            title.TitleImages = bookDetails.TitleImages.Select(ConvertImage).ToList();
            title.Type = bookDetails.Type;
            title.Writer = bookDetails.Writer;

            return title;
        }

        internal static LibraryBook ConvertUpdate(LibraryBook book, LibraryBookDto bookDetails)
        {
            book.Id = bookDetails.Id;
            book.Name = bookDetails.Name;
            book.Bearer = bookDetails.Bearer;
            book.Condition = bookDetails.Condition;
            book.Stock = bookDetails.Stock;

            return book;
        }
    }
}
