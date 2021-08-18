const { CheckerPlugin } = require('awesome-typescript-loader');
const { join } = require('path');
const { optimize } = require('webpack');
const config = require("./webpack.config");

module.exports = {
  ...config,
  mode: 'production',
  plugins: [
    ...config.plugins,
    new optimize.AggressiveMergingPlugin()
  ],
};
