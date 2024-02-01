// Hussy.Net offers many functions for writing
// to the output stream, the simplest of which
// is W for "write line".
W("Hello, world!");

// If you need to write a separator, then
// the WS function can meet your needs
// with optional character and length
// parameters. The default character
// is '=' and the default length is
// 25.
WS(character: '_', length: 30);

// You can simply append to the stream
// using the A function:
A("Fizz");
A("Buzz");

// If you need to separate your output into
// visible chunks, then the WH method
// can facilitate writing a line preceded
// by two new lines.
WH("Sample Header");