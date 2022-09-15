# Contributing to FIT FIKS
## Issues
Please create a separate issue for any missing feature or a bug.  
Keep issues very granular and link between them if necessary.

## Merge requests
Create draft merge requests for WIP functionality and mark them as ready only after your want them to be reviewed.  
Same as with issues, please keep merge requests as granular as possible, to allow better control of the flow of the repository.

## Conventional Commits
Please use [Conventional Commits](https://www.conventionalcommits.org/en/v1.0.0/#summary) whenever possible when contributing.

Conventional commits are a type of commit messages that are easy to read for both humans and computers.
They are useful for generating release notes, forcing programmers to split larger changes into smaller commits and overall improve readability.

#### Format
```text
<type>(<scope>): <summary>

<detailed summary>
```

#### Types
The type of change in the commit.
```text
feat - a change to the codebase possibly changing any functionality
fix - mostly bugfixes or fixes or wrong design
test - changes concerning tests (adding tests to improve coverage, ...)
style - reformatting the code without any change to its functionality
docs - change concerning the documentation or in-code comments
ci - changes concerning the CI/CD toolchain (Dockerfiles, ...)
```

#### Scope
The scope of the commit. Optional, but recommended.
```text
model - changes regarding database models or their derivatives
database - changes to the database logic
frontend - change to the frontend
...
```

#### Summary
Use present simple tense when describing changes.  
Keep the summary short and information dense. If you cannot describe the change in a short summary, you should split the commit into smaller ones.

#### Example
```text
feat(frontend): center a div

feat(backend): change the hashing function from MD5 to Argon2
```