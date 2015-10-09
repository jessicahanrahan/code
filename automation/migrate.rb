module Automation
  class Migrate < Thor
    include ::Automation::Compile::CompileUnitResolution
    namespace :migrate

    [
      :migrate,
      :rollback,
      :validate_version_order,
      :list_migrations
    ].each do |task|
      actual_task_name = "#{task}".gsub(/_/, "")

      instance_eval do
        desc "#{task}", "Runs the migration task: #{actual_task_name}"
        define_method(task) do |unit|
          invoke 'compile:project'
          compile_unit = get_compile_unit(unit)
          runner = MigrationRunner.new(compile_unit)
          runner.run_task(actual_task_name)
        end
      end
    end

    class MigrationRunner
      attr_reader :compile_unit

      def initialize(unit)
        @compile_unit = unit
      end

      def base_options
        @base_options ||= {
          connectionString: "code",
          connectionStringConfigPath: 'source\config\web.config',
          assembly: compile_unit.output.win_path,
          provider: settings.database.provider_for_migrations
        }
      end

      def run_task(task_name)
        exec(task: task_name)
      end

      def exec(options={})
        all_options = base_options.merge(options)

        commands = []
        commands << settings.migrate.exe

        all_options.each do |key, value|
          commands << "--#{key}=#{value}" 
        end

        command = commands.join(" ")
        puts command
        system(command)
      end
    end

  end
end
