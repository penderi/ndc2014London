namespace Common.Assets
{
    public class Resources
    {
        //function names here are referenced in Container calls
        public static string Html = @"<html>
<head>
<link rel='stylesheet' type='text/css' href='ndc://local.css'>
</head>
<body onload=""window.csfromjs.sentFromUI('sent from js to cs at ndc London');"">
<script  type='text/javascript'>
    window.toUI =function (passedStr) {
    console.log('received in js from cs:' + passedStr);
    }
</script>

<h1>GO!</h1>
</body></html>";


        public static string Css = "* { color: red;}";
    }
}