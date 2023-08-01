using Strategy;
using static Strategy.DynamicStrategy;
using MarkdownListStrategy = Strategy.DynamicStrategy.MarkdownListStrategy;


    //var tp = new TextProcessor();
    //tp.SetOutputFormat(OutputFormat.Markdown);
    //tp.AppendList(new[] { "foo", "bar", "baz" });
    //Console.WriteLine(tp);

    //tp.Clear();
    //tp.SetOutputFormat(OutputFormat.Html);
    //tp.AppendList(new[] { "foo", "bar", "baz" });
    //Console.WriteLine(tp);


    ////Static 
    //var tp1 = new TextProcessor<MarkdownListStrategy>();
    //tp.AppendList(new[] { "foo", "bar", "baz" });
    //Console.WriteLine(tp1);

    //var tp2 = new TextProcessor<HtmlListStrategy>();
    //tp2.AppendList(new[] { "foo", "bar", "baz" });
    //Console.WriteLine(tp2);

    var solver = new QuadraticEquationSolver(new RealDiscriminantStrategy());
    var x = solver.Solve(1, 2, 3);

