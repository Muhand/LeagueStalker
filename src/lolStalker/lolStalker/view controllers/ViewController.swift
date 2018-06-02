//
//  ViewController.swift
//  lolStalker
//
//  Created by Muhand Jumah on 5/31/18.
//  Copyright © 2018 Muhand Jumah. All rights reserved.
//

import UIKit

class ViewController: UIViewController {
    ////////////////////////////////////
    //            Controls
    ////////////////////////////////////
    let loginView: LoginForm = {
        let view = LoginForm()
        return view
    }()
    
    
    ////////// END OF CONTROLS /////////
    override func viewDidLoad() {
        super.viewDidLoad()
        setupView()
        setupSubViews()
        setupConstraints()
        setupMargins()
    }
    
    func setupView() {
        view.backgroundColor = UIColor(hex: "#010A13")
    }
    
    func setupSubViews() {
        view.addSubview(loginView)
//        view.addSubview(logo)
//        view.addSubview(emailField)
    }
    
    func setupConstraints() {
//                view.addConstraintsWithFormat(format: "H:|[v0]|", views: loginView)
//                view.addConstraintsWithFormat(format: "V:|[v0]|", views: loginView)
//        view.addConstraintsWithFormat(format: "H:|[v0]|", views: loginView)
//        view.addConstraintsWithFormat(format: "V:[v0]", views: emailField)
    }
    
    func setupMargins() {
        self.loginView.center = self.view.center
//        self.logo.center.x = self.view.center.x
//        self.logo.center.y = ((self.view.frame.height * 25) / 100)
//        self.emailField.center.y = ((self.view.frame.height * 50) / 100)
    }
    
    override func viewWillTransition(to size: CGSize, with coordinator: UIViewControllerTransitionCoordinator) {
        super.viewWillTransition(to: size, with: coordinator)
        view.setNeedsDisplay()
    }
}

