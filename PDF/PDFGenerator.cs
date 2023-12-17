using iTextSharp.text;
using iTextSharp;
using Microsoft.JSInterop;
using iTextSharp.text.pdf;
using SistemaReservaSalas.Data;

namespace SistemaReservaSalas.PDF
{

    public class PDFGenerator
    {

        public void DownloadPdf(IJSRuntime js, List<Sala> salas, List<User> users, List<ReservaPorSala> reservasPorSala, List<ReservaPorUser> reservasPorUser, string filename = "report.pdf")
        {
            js.InvokeVoidAsync("DownloadPdf", filename, Convert.ToBase64String(PDFReport(salas, users, reservasPorSala, reservasPorUser)));
        }
        public void ViewPdfNewTab(IJSRuntime js, string filename = "report.pdf")
        {

        }

        private byte[] PDFReport(List<Sala> salas, List<User> users, List<ReservaPorSala> reservasPorSala, List<ReservaPorUser> reservasPorUser)
        {
            var memoryStream = new MemoryStream();
            float margeLeft = 1.5f;
            float margeRight = 1.5f;
            float margeTop = 1.0f;
            float margeBottom = 1.0f;

            Document pdf = new Document(
                PageSize.A4,
                margeLeft,
                margeRight,
                margeTop,
                margeBottom
            );

            pdf.AddTitle("Blazor PDF");
            pdf.AddAuthor("Enio Filipe");
            pdf.AddCreationDate();
            pdf.AddKeywords("Blazor");
            pdf.AddSubject("Gerando o nosso pdfzinho");

            PdfWriter writer = PdfWriter.GetInstance(pdf, memoryStream);

            // Create header

            var fontStyle = FontFactory.GetFont("Arial", 16, BaseColor.White);
            var labelHeader = new Chunk("Blazor PDF Header", fontStyle);

            HeaderFooter header = new HeaderFooter(new Phrase(labelHeader), false)
            {
                BackgroundColor = new BaseColor(50, 20, 120),
                Alignment = Element.ALIGN_CENTER,
                Border = Rectangle.NO_BORDER
            };
            pdf.Header = header;

            // Create Footer
            var labelFooter = new Chunk("Page", fontStyle);

            HeaderFooter footer = new HeaderFooter(new Phrase(labelFooter), false)
            {
                BackgroundColor = new BaseColor(120, 3, 120),
                Alignment = Element.ALIGN_RIGHT,
                Border = Rectangle.NO_BORDER
            };
            pdf.Footer = footer;


            //Body

            pdf.Open();

            var title = new Paragraph("RELATORIO DOTNET RESERVA DE SALA", new Font(Font.HELVETICA, 20, Font.BOLD));
            title.SpacingAfter = 18f;
            pdf.Add(title);

            Font _fontStyle = FontFactory.GetFont("Tahoma", 12f, Font.NORMAL);

            // -- Lista de salas
            // --- Quantidade de salas
            var _mytext = "Salas";
            var phrase = new Phrase(_mytext, _fontStyle);
            pdf.Add(phrase);

            var _quantidadeSalasText = "Quantidade de salas: " + salas.Count;
            phrase = new Phrase(_quantidadeSalasText, _fontStyle);
            pdf.Add(phrase);

            Table table = new Table(3);
            table.BorderWidth = 1f;
            table.BorderColor = new BaseColor(0, 0, 255);
            table.Padding = 2f;
            table.Spacing = 5f;

            Cell cell = new Cell("ID");
            cell.Header = true;
            table.AddCell(cell);

            cell = new Cell("Nome da sala");
            cell.Header = true;
            table.AddCell(cell);

            cell = new Cell("Descricao");
            cell.Header = true;
            table.AddCell(cell);

            table.EndHeaders();

            salas.ForEach(sala =>
            {
                table.AddCell("" + sala.Id);
                table.AddCell("" + sala.Nome);
                table.AddCell("" + sala.Descricao);
            });


            pdf.Add(table);


            //-- Lista de usuários
            //--- Quantidade de usuários

            pdf.NewPage();

            _mytext = "Usuários";
            phrase = new Phrase(_mytext, _fontStyle);
            pdf.Add(phrase);

            var _quantidadeUsuariosText = "Quantidade de usuarios: " + users.Count;
            phrase = new Phrase(_quantidadeUsuariosText, _fontStyle);
            pdf.Add(phrase);

            Table tableUsers = new Table(3);
            tableUsers.BorderWidth = 1f;
            tableUsers.BorderColor = new BaseColor(0, 0, 255);
            tableUsers.Padding = 2f;
            tableUsers.Spacing = 5f;

            cell = new Cell("ID");
            cell.Header = true;
            tableUsers.AddCell(cell);

            cell = new Cell("Nome do Usuário");
            cell.Header = true;
            tableUsers.AddCell(cell);

            cell = new Cell("Email");
            cell.Header = true;
            tableUsers.AddCell(cell);

            tableUsers.EndHeaders();

            users.ForEach(user =>
            {
                tableUsers.AddCell("" + user.Id);
                tableUsers.AddCell("" + user.Nome);
                tableUsers.AddCell("" + user.Email);
            });

            pdf.Add(tableUsers);

            // -- Quantidade de reserva por salas
            pdf.NewPage();

            _mytext = "Quantidade de reservas por salas";
            phrase = new Phrase(_mytext, _fontStyle);
            pdf.Add(phrase);

            Table tableReservasPorSala = new Table(3);
            tableReservasPorSala.BorderWidth = 1f;
            tableReservasPorSala.BorderColor = new BaseColor(0, 0, 255);
            tableReservasPorSala.Padding = 2f;
            tableReservasPorSala.Spacing = 5f;

            cell = new Cell("ID");
            cell.Header = true;
            tableReservasPorSala.AddCell(cell);

            cell = new Cell("Nome da sala");
            cell.Header = true;
            tableReservasPorSala.AddCell(cell);

            cell = new Cell("Quantidade");
            cell.Header = true;
            tableReservasPorSala.AddCell(cell);

            tableReservasPorSala.EndHeaders();

            reservasPorSala.ForEach(rs =>
            {
                tableReservasPorSala.AddCell("" + rs.SalaId);
                tableReservasPorSala.AddCell("" + rs.Nome);
                tableReservasPorSala.AddCell("" + rs.Quantidade);
            });

            pdf.Add(tableReservasPorSala);
            //-- Quantidade de resrvas por usuários

            pdf.NewPage();

            _mytext = "Quantidade de reservas por usuários";
            phrase = new Phrase(_mytext, _fontStyle);
            pdf.Add(phrase);

            Table tableReservasPorUsuario = new Table(3);
            tableReservasPorUsuario.BorderWidth = 1f;
            tableReservasPorUsuario.BorderColor = new BaseColor(0, 0, 255);
            tableReservasPorUsuario.Padding = 2f;
            tableReservasPorUsuario.Spacing = 5f;

            cell = new Cell("ID");
            cell.Header = true;
            tableReservasPorUsuario.AddCell(cell);

            cell = new Cell("Nome do usuário");
            cell.Header = true;
            tableReservasPorUsuario.AddCell(cell);

            cell = new Cell("Quantidade");
            cell.Header = true;
            tableReservasPorUsuario.AddCell(cell);

            tableReservasPorUsuario.EndHeaders();

            reservasPorUser.ForEach(ru =>
            {
                tableReservasPorUsuario.AddCell("" + ru.UserId);
                tableReservasPorUsuario.AddCell("" + ru.Nome);
                tableReservasPorUsuario.AddCell("" + ru.Quantidade);
            });

            pdf.Add(tableReservasPorUsuario);

            pdf.Close();
            return memoryStream.ToArray();
        }

    }
}