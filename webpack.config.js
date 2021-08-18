const { CheckerPlugin } = require('awesome-typescript-loader');
const CopyPlugin = require("copy-webpack-plugin");
const { join } = require('path');



module.exports = {
  mode: 'development',
  devtool: 'inline-source-map',
  entry: {
    'content-script': join(__dirname, 'src/content-script.ts'),
    background: join(__dirname, 'src/background.ts')
  },
  output: {
    path: join(__dirname, './dist'),
    filename: '[name].js'
  },
  module: {
    rules: [
      {
        exclude: /node_modules/,
        test: /\.ts?$/,
        use: 'awesome-typescript-loader?{configFileName: "tsconfig.json"}'
      }
    ]
  },
  plugins: [
    new CheckerPlugin(),
    new CopyPlugin({
      patterns: [
        { from: "manifest.json", context: "src/" },
        { from: "*icon.png", context: "src/" },
      ],
    }),
  ],
  resolve: {
    extensions: ['.ts', '.js']
  }
};
