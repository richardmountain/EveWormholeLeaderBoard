/// <binding BeforeBuild='all' />
module.exports = function (grunt) {

    grunt.initConfig({
        clean: ["wwwroot/*", "Temp/"],
        copy: {
            main: {
                files: [
                    // includes files within path and its sub-directories
                    //{ expand: true, src: ['path/**'], dest: 'dest/' },

                    // flattens results to a single level
                    //{ expand: true, flatten: true, src: ['path/**'], dest: 'dest/', filter: 'isFile' },
                ],
            },
        },
        concat: {
            all: {
                src: ['Scripts/site.js'],
                dest: 'Temp/site.js'
            }
        },
        jshint: {
            files: ['Temp/*.js'],
            options: {
                '-W069': false,
            }
        },
        uglify: {
            all: {
                src: ['Temp/site.js'],
                dest: 'wwwroot/js/site.min.js'
            }
        },
        watch: {
            files: ["Scripts/*.js"],
            tasks: ["all"]
        },
        sass: {
            dist: {
                options: {
                    style: 'expanded'
                },
                files: {
                    'wwwroot/css/main.css': 'Sass/main.scss'
                }
            }
        }
    });

    grunt.loadNpmTasks("grunt-contrib-clean");
    grunt.loadNpmTasks("grunt-contrib-jshint");
    grunt.loadNpmTasks("grunt-contrib-concat");
    grunt.loadNpmTasks("grunt-contrib-uglify");
    grunt.loadNpmTasks("grunt-contrib-watch");
    grunt.loadNpmTasks("grunt-contrib-sass");
    grunt.loadNpmTasks("grunt-contrib-copy");

    grunt.registerTask("all", ['clean', 'copy', 'concat', 'jshint', 'uglify', 'sass']);

};