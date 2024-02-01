// Hussy has a built-in hello world module.
// It's default output is "Hello, world!".
W("Default");
WS();
Yo();

// If you need a common variation of the output,
// then you can specify a variant ID to change it.
WH("Default (variant)");
WS();
Yo(1);

// If a predefined variant doesn't exist,
// then you can always write it from scratch:
WH("Custom");
WS();
W("...hello...world...");